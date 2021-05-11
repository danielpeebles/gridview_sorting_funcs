  protected void gvResults_Sorting(object sender, GridViewSortEventArgs e)
    {

        try
        {

            string sSortDir = GetSortDirection(e.SortExpression);


            DataTable dt = PopulateData();
            if (dt != null && dt.Rows.Count > 0)
            {
                dt.DefaultView.Sort = e.SortExpression + " " + sSortDir;
                gvResults.DataSource = dt;
                gvResults.DataBind();
            }
            else
            {
                gvResults.DataSource = null;
                gvResults.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Write("<span style=\"color:red\">PopulateDataGrid ERROR: " + ex.Message + "</span>");
        }



    }

    private string GetSortDirection(string column)
    {

        // By default, set the sort direction to ascending.
        string sortDirection = "ASC";

        // Retrieve the last column that was sorted.
        string sortExpression = ViewState["SortExpression"] as string;

        if (sortExpression != null)
        {
            // Check if the same column is being sorted.
            // Otherwise, the default value can be returned.
            if (sortExpression == column)
            {
                string lastDirection = ViewState["SortDirection"] as string;
                if ((lastDirection != null) && (lastDirection == "ASC"))
                {
                    sortDirection = "DESC";
                }
            }
        }

        // Save new values in ViewState.
        ViewState["SortDirection"] = sortDirection;
        ViewState["SortExpression"] = column;

        return sortDirection;
    }


    protected DataTable PopulateData()
    {
        return null;
    }
