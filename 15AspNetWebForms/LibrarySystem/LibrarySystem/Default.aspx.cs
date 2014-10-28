using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LibrarySystem.Models;

namespace LibrarySystem
{
    public partial class _Default : Page
    {
        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Category> ListViewCategories_GetData()
        {
            LibraryDbContext db = new LibraryDbContext();
            return db.Categories;
        }

        protected void SeachButton_Click(object sender, EventArgs e)
        {
            string seachParam = this.searchField.Value;

            Response.Redirect("~/Search?q=" + seachParam);
        }
    }
}