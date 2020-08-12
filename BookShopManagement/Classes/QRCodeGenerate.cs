using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zen;

namespace BookShopManagement.Classes
{
    class QRCodeGenerate
    {
       public Image ticketQRCode(string customer,string movieName, string date, string timeSlot)
        {
            string ticketData = "Dear " + customer + " we warmly welcome you to " + movieName + " on " + 
                date + " at " + timeSlot + " to skyline 3D Cinema";
            Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            PictureBox p = new PictureBox();
            return qrcode.Draw(ticketData, 25);
            
        }

        public Image trailerLinkQRcode(string link)
        {
            Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            PictureBox p = new PictureBox();
            return qrcode.Draw(link, 50);
           
        }
        
    }
}
