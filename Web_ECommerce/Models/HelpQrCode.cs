using Entities.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using PdfSharpCore;
using PdfSharpCore.Drawing;

namespace Web_ECommerce.Models
{
    public class HelpQrCode : Controller
    {

        private async Task<byte[]> GeraQrCode(string dadosBanco)
        {
            QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();

            QRCodeData qRCodeData = qrCodeGenerator.CreateQrCode(dadosBanco, QRCodeGenerator.ECCLevel.H);

            QRCode qRCode = new QRCode(qRCodeData);

            Bitmap qrCodeImage = qRCode.GetGraphic(20);

            var bitMapToBytes = BitMapToBytes(qrCodeImage);

            return bitMapToBytes;
        }

        private static byte[] BitMapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

                return stream.ToArray();
            }
        }

        public async Task<IActionResult> Download(CompraUsuario compraUsuario, IWebHostEnvironment environment)
        {
            using(var doc = new PdfSharpCore.Pdf.PdfDocument())
            {
                #region Configuração de folha
                var page = doc.AddPage();

                page.Size = PdfSharpCore.PageSize.A4;
                page.Orientation = PdfSharpCore.PageOrientation.Portrait;

                var graphics = XGraphics.FromPdfPage(page);
                var corFonte = XBrushes.Black;
                #endregion

                #region Numeração de páginas

                int qtdPaginas = doc.PageCount;

                var numeracaoPaginas = new PdfSharpCore.Drawing.Layout.XTextFormatter(graphics);
                numeracaoPaginas.DrawString(Convert.ToString(qtdPaginas), new PdfSharpCore.Drawing.XFont("arial", 10), corFonte, new PdfSharpCore.Drawing.XRect(575, 825, page.Width, page.Height));

                #endregion

                #region Logo
                var webRoot = environment.WebRootPath;

                var logoFatura = string.Concat(webRoot, "/img/", "loja-virtual-1.png");

                XImage image = XImage.FromFile(logoFatura);

                graphics.DrawImage(image, 20, 5, 300, 50);
                #endregion

                #region Informações 1
                var relatorioCombranca = new PdfSharpCore.Drawing.Layout.XTextFormatter(graphics);

                var titulo = new PdfSharpCore.Drawing.XFont("Arial", 14, PdfSharpCore.Drawing.XFontStyle.Bold);

                relatorioCombranca.Alignment = PdfSharpCore.Drawing.Layout.XParagraphAlignment.Center;

                relatorioCombranca.DrawString("BOLETO ONLINE", titulo, corFonte, new XRect(0, 65, page.Width, page.Height));

                #endregion

                #region Informações 2
                var alturaTitulosDetalhesY = 120;

                var detalhes = new PdfSharpCore.Drawing.Layout.XTextFormatter(graphics);

                var tituloInfo_1 = new PdfSharpCore.Drawing.XFont("Arial", 8, XFontStyle.Regular);

                detalhes.DrawString("Dados do banco", tituloInfo_1, corFonte, new XRect(25, alturaTitulosDetalhesY, page.Width, page.Height));
                detalhes.DrawString("Banco Itau 004", tituloInfo_1, corFonte, new XRect(150, alturaTitulosDetalhesY, page.Width, page.Height));

                alturaTitulosDetalhesY += 9;
                detalhes.DrawString("Código Gerado:", tituloInfo_1, corFonte, new XRect(25, alturaTitulosDetalhesY, page.Width, page.Height));
                detalhes.DrawString("000000 000000 000000 000000", tituloInfo_1, corFonte, new XRect(150, alturaTitulosDetalhesY, page.Width, page.Height));

                alturaTitulosDetalhesY += 9;
                detalhes.DrawString("Quantidade:", tituloInfo_1, corFonte, new XRect(25, alturaTitulosDetalhesY, page.Width, page.Height));
                detalhes.DrawString(compraUsuario.QuantidadeProdutos.ToString(), tituloInfo_1, corFonte, new XRect(150, alturaTitulosDetalhesY, page.Width, page.Height));

                alturaTitulosDetalhesY += 9;
                detalhes.DrawString("Valor Total:", tituloInfo_1, corFonte, new XRect(25, alturaTitulosDetalhesY, page.Width, page.Height));
                detalhes.DrawString(compraUsuario.ValorTotal.ToString(), tituloInfo_1, corFonte, new XRect(150, alturaTitulosDetalhesY, page.Width, page.Height));

                var tituloInfo_2 = new PdfSharpCore.Drawing.XFont("Arial", 8, XFontStyle.Bold);

                try
                {
                    var img = await GeraQrCode("Banco de dados aqui");

                    Stream streamImage = new MemoryStream(img);

                    XImage qrCode = XImage.FromStream(() => streamImage);

                    alturaTitulosDetalhesY += 40;
                    graphics.DrawImage(qrCode, 140, alturaTitulosDetalhesY, 310, 310);
                }
                catch (Exception)
                {

                    throw;
                }

                alturaTitulosDetalhesY += 620;
                detalhes.DrawString("Canhoto com QrCode para pagamentos online", tituloInfo_2, corFonte, new XRect(20, alturaTitulosDetalhesY, page.Width, page.Height));

                #endregion

                using (MemoryStream stream = new MemoryStream())
                {
                    var contentType = "application/pfd";

                    doc.Save(stream, false);
                    return File(stream.ToArray(), contentType, "BoletoLojaOnline.pdf");
                }
            }
        }
    }
}
