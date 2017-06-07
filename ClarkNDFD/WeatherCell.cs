using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace ClarkNDFD
{
    public class WeatherCell : UITableViewCell
    {
        //public UILabel headingLabel, subheadingLabel;
        //public UIImageView imageView;

        public UILabel timeLabel;
        public UIImageView temperatureImage;
        public UILabel temperatureApparentLabel;
        public UILabel highTempLabel;
        public UILabel lowTempLabel;
        public UILabel precMainLabel;
        public UILabel precSubLabel;

        public WeatherCell() : base(UITableViewCellStyle.Default, "")
        {
            SelectionStyle = UITableViewCellSelectionStyle.Gray;
            timeLabel = new UILabel()
            {

            };
            temperatureImage = new UIImageView();
			temperatureApparentLabel = new UILabel()
			{

			};
			highTempLabel = new UILabel()
			{

			};
			lowTempLabel = new UILabel()
			{

			};
			precMainLabel = new UILabel()
			{

			};
			precSubLabel = new UILabel()
			{

			};

            /*imageView = new UIImageView();
			headingLabel = new UILabel()
			{
				//Font = UIFont.FromName("Cochin-BoldItalic", 22f),
				//TextColor = UIColor.FromRGB(127, 51, 0),
				BackgroundColor = UIColor.Clear
			};
			subheadingLabel = new UILabel()
			{
				//Font = UIFont.FromName("AmericanTypewriter", 12f),
				//TextColor = UIColor.FromRGB(38, 127, 0),
				TextAlignment = UITextAlignment.Center,
				BackgroundColor = UIColor.Clear
			};*/
            ContentView.AddSubviews(new UIView[] {timeLabel, temperatureImage, 
                temperatureApparentLabel, highTempLabel, lowTempLabel, precMainLabel, precSubLabel});
        }

		public void UpdateCell(string[] items)
		{
            timeLabel.Text = items[0];
            // TODO This causes lag
            //temperatureImage.Image = _Utilities.Utilities.LoadImage(items[1]).Result;
            temperatureApparentLabel.Text = items[2];
            highTempLabel.Text = items[3];
            lowTempLabel.Text = items[4];
            precMainLabel.Text = items[5];
            precSubLabel.Text = items[6];

			//headingLabel.Text = caption;
			//subheadingLabel.Text = subtitle;
		}
		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

            timeLabel.Frame = new CGRect(5, 4, ContentView.Bounds.Width - 63, 25);
            temperatureImage.Frame = new CGRect(0.0f, 0.0f, 0.0f, 0.0f);
            temperatureApparentLabel.Frame = new CGRect(100, 18, 100, 20);
            highTempLabel.Frame = new CGRect(100, 35, 100, 20);
            lowTempLabel.Frame = new CGRect(200, 18, 100, 20);
            precMainLabel.Frame = new CGRect(200, 35, 100, 20);
            precSubLabel.Frame = new CGRect(ContentView.Bounds.Width - 63, 5, 33, 33);

			//imageView.Frame = new CGRect(ContentView.Bounds.Width - 63, 5, 33, 33);
			//headingLabel.Frame = new CGRect(5, 4, ContentView.Bounds.Width - 63, 25);
			//subheadingLabel.Frame = new CGRect(100, 18, 100, 20);
		}
    }
}
