using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsSystemWeb.Controls
{
    public partial class Likes : System.Web.UI.UserControl
    {
        protected void downvoteBtnClick(object sender, EventArgs e)
        {
            if (this.Downvote != null)
            {
                this.Downvote(this, new EventArgs());
            }
        }

        protected void upvoteBtnClick(object sender, EventArgs e)
        {
            if (this.Upvote != null)
            {
                this.Upvote(this, new EventArgs());
            }
        }

        public int TotalLikes
        {
            get
            {
                return Convert.ToInt32(this.LikesCount.Text);
            }
            set
            {
                this.LikesCount.Text = value.ToString();
            }
        }

        public event EventHandler Upvote;

        public event EventHandler Downvote;
    }
}