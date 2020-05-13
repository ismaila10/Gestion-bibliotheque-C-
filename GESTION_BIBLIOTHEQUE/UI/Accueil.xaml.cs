using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GESTION_BIBLIOTHEQUE.UI
{
    /// <summary>
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class Accueil : UserControl
    {
        public Accueil()
        {
            InitializeComponent();
            Defiler("Bienvenue");

            List<string> li = new List<string>();

            li.Add("Une bibliotheque c'est un des plus beau paysage du monde !");
            li.Add("Un viellard qui meurt , c'est un bibliotheque qui s'effond !");
            li.Add(" Gaston Bachelar : Un bibliotheque est un sanctuaire de la pensée pure");

            for (int i = 0; i < li.Count; i++)
            {
                Random r = new Random();
                int n = r.Next(0,(li.Count-1));
                Defiler2(li[n]);
            }
          
        }
        

        /*private void button1_Click(object sender, RoutedEventArgs e)
        {
           // Defiler(txtTexttoScroll.Text);
            double textBoxWidth = 10;

            double pixelXFactor;
            double canvaswidth = this.canvas1.Width;
            double negXOffSet = 0;
            double fromSecValue = 0;
            double equSlope = 0.022546419;
            double offSetY = 10.96286472;
            double stringSize;

            int textLen = txtTexttoScroll.Text.Length;

            //Set the width of the text box according to the width (not length) of the text in it.  
            System.Globalization.CultureInfo enUsCultureInfo;
            Typeface fontTF;
            FormattedText frmmtText;
            if (textLen > 0)
            {
                enUsCultureInfo = System.Globalization.CultureInfo.GetCultureInfo("en-us");
                fontTF = new Typeface(this.textBlock1.FontFamily, this.textBlock1.FontStyle, this.textBlock1.FontWeight, this.textBlock1.FontStretch);
                frmmtText = new FormattedText(txtTexttoScroll.Text, enUsCultureInfo, FlowDirection.LeftToRight, fontTF, this.textBlock1.FontSize, this.textBlock1.Foreground);

                stringSize = frmmtText.Width;

                if (stringSize < 100)
                    pixelXFactor = 1.02;
                else
                    pixelXFactor = 1.01;

                textBoxWidth = stringSize * pixelXFactor;

                this.textBlock1.Width = textBoxWidth;
                negXOffSet = textBoxWidth * -1;

                fromSecValue = (stringSize * equSlope) + offSetY;

                this.textBlock1.Text = txtTexttoScroll.Text;

                Storyboard _sb = new Storyboard();
                Duration durX = new Duration(TimeSpan.FromSeconds(fromSecValue));
                DoubleAnimation daX = new DoubleAnimation(canvaswidth, negXOffSet, durX);
                daX.RepeatBehavior = RepeatBehavior.Forever;

                Storyboard.SetTargetName(daX, "rtTTransform");
                Storyboard.SetTargetProperty(daX, new PropertyPath(TranslateTransform.XProperty));

                _sb.Children.Add(daX);
                _sb.Begin(this.textBlock1);
            }
            else
            {
                textBoxWidth = 1;
                stringSize = 0;
            }
        }*/

        private void Defiler(string s)
        {
            double textBoxWidth = 10;

            double pixelXFactor;
            double canvaswidth = this.canvas1.Width;
            double negXOffSet = 0;
            double fromSecValue = 0;
            double equSlope = 0.022546419;
            double offSetY = 10.96286472;
            double stringSize;

            int textLen = s.Length;

            //Set the width of the text box according to the width (not length) of the text in it.  
            System.Globalization.CultureInfo enUsCultureInfo;
            Typeface fontTF;
            FormattedText frmmtText;
            if (textLen > 0)
            {
                enUsCultureInfo = System.Globalization.CultureInfo.GetCultureInfo("en-us");
                fontTF = new Typeface(this.textBlock1.FontFamily, this.textBlock1.FontStyle, this.textBlock1.FontWeight, this.textBlock1.FontStretch);
                frmmtText = new FormattedText(s, enUsCultureInfo, FlowDirection.LeftToRight, fontTF, this.textBlock1.FontSize, this.textBlock1.Foreground);

                stringSize = frmmtText.Width;

                if (stringSize < 100)
                    pixelXFactor = 1.02;
                else
                    pixelXFactor = 1.01;

                textBoxWidth = stringSize * pixelXFactor;

                this.textBlock1.Width = textBoxWidth;
                negXOffSet = textBoxWidth * -1;

                fromSecValue = (stringSize * equSlope) + offSetY;

                this.textBlock1.Text =s;

                Storyboard _sb = new Storyboard();
                Duration durX = new Duration(TimeSpan.FromSeconds(fromSecValue));
                DoubleAnimation daX = new DoubleAnimation(canvaswidth, negXOffSet, durX);
                daX.RepeatBehavior = RepeatBehavior.Forever;

                Storyboard.SetTargetName(daX, "rtTTransform1");
                Storyboard.SetTargetProperty(daX, new PropertyPath(TranslateTransform.XProperty));

                _sb.Children.Add(daX);
                _sb.Begin(this.textBlock1);
            }
            else
            {
                textBoxWidth = 1;
                stringSize = 0;
            }
        }

        private void Defiler2(string s)
        {
            double textBoxWidth = 10;

            double pixelXFactor;
            double canvaswidth = this.canvas1.Width;
            double negXOffSet = 0;
            double fromSecValue = 0;
            double equSlope = 0.022546419;
            double offSetY = 10.96286472;
            double stringSize;

            int textLen = s.Length;

            //Set the width of the text box according to the width (not length) of the text in it.  
            System.Globalization.CultureInfo enUsCultureInfo;
            Typeface fontTF;
            FormattedText frmmtText;
            if (textLen > 0)
            {
                enUsCultureInfo = System.Globalization.CultureInfo.GetCultureInfo("en-us");
                fontTF = new Typeface(this.textBlock2.FontFamily, this.textBlock2.FontStyle, this.textBlock2.FontWeight, this.textBlock2.FontStretch);
                frmmtText = new FormattedText(s, enUsCultureInfo, FlowDirection.LeftToRight, fontTF, this.textBlock2.FontSize, this.textBlock2.Foreground);

                stringSize = frmmtText.Width;

                if (stringSize < 100)
                    pixelXFactor = 1.02;
                else
                    pixelXFactor = 1.01;

                textBoxWidth = stringSize * pixelXFactor;

                this.textBlock2.Width = textBoxWidth;
                negXOffSet = textBoxWidth * -1;

                fromSecValue = (stringSize * equSlope) + offSetY;

                this.textBlock2.Text = s;

                Storyboard _sb = new Storyboard();
                Duration durX = new Duration(TimeSpan.FromSeconds(fromSecValue));
                DoubleAnimation daX = new DoubleAnimation(canvaswidth, negXOffSet, durX);
                daX.RepeatBehavior = RepeatBehavior.Forever;

                Storyboard.SetTargetName(daX, "rtTTransform2");
                Storyboard.SetTargetProperty(daX, new PropertyPath(TranslateTransform.XProperty));

                _sb.Children.Add(daX);
                _sb.Begin(this.textBlock2);
            }
            else
            {
                textBoxWidth = 1;
                stringSize = 0;
            }
        }
    }
}
