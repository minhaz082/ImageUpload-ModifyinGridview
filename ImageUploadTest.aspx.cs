using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using EATL.DAL;
using EATL.BLL.Facade;
using System.Data;

namespace EATL.WebClient.CommonUI
{
    public partial class ImageUploadTest : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=192.168.1.4;Initial Catalog=MeghnaSolar;User ID=sa;Password=dba@123");
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ImgCustomerPicture.Visible = false;
                //BindGridView();
                loadGridviewWithImage();
            }
        }               
        
        protected void btnUpload_Click_Old(object sender, EventArgs e)
        {
        //    if (file.HasFile)
        //    {
        //        string filename = file.FileName;
        //        string filepath = Server.MapPath("~/Images/");
        //        lblImagePath.Text = filepath + filename;
        //        int fileLength = file.PostedFile.ContentLength;
        //        string fileExtention = Path.GetExtension(filename);
        //        fileExtention = fileExtention.ToLower();
        //        string link = "~/Images/" + filename;
        //        //string fileName = Path.Combine(@"D:\ImageUpload", filename);    file name given exact location in the dish of user

        //        if (fileLength < 1048576)
        //        {
        //            if (fileExtention == ".jpg" || fileExtention == ".png" || fileExtention == ".gif" || fileExtention == ".bmp")
        //            {
        //                file.SaveAs(filepath + filename);
        //                ImgCustomerPicture.Visible = true;
        //                ImgCustomerPicture.ImageUrl = "~/Images/" + filename;


        //                string[] filePaths = Directory.GetFiles(Server.MapPath("~/Images/"));
        //                List<ListItem> files = new List<ListItem>();
        //                foreach (string filePath in filePaths)
        //                {
        //                    string fileName = Path.GetFileName(filePath);
        //                    string customerName = "Abul";

        //                    files.Add(new ListItem(customerName, "~/Images/" + fileName));
        //                }
        //                //grvCustomerPicture.DataSource = files;
        //                //grvCustomerPicture.DataBind();
        //                GridView1.DataSource = files;
        //                GridView1.DataBind();
        //            }
        //            else
        //            {
        //                Response.Write("<script>alert('Only image files are allowed');</script>");
        //            }
        //        }
        //        else
        //        {
        //            Response.Write("<script>alert('Max file size allowed is 1 MB');</script>");
        //        }

        //    }
        //    else
        //    {
        //        Response.Write("<script>alert('Please Select File To Upload');</script>");
        //    }
        }

        
        protected CustomerImage CreateCustomerImage()
        {
            CustomerImage customerImage = new CustomerImage();

            //customerImage.CustomerID = 1;
            //customerImage.ImageLocation = lblImagePath.Text;
            //customerImage.CreateBy = Convert.ToInt64(Session["UserID"]);
            //customerImage.CreateDate = GeneralConfigurationFacade.GetServerDateTime();
            //customerImage.UpdateBy = Convert.ToInt64(Session["UserID"]);
            //customerImage.Updatedate = GeneralConfigurationFacade.GetServerDateTime();
            //customerImage.IsRemove = false;
            return customerImage;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //if (CheckBox.Checked)
            //{
            //    using (LeasingFacade _facade = new LeasingFacade())
            //    {
            //        CustomerImage customerImage = CreateCustomerImage();
            //        _facade.AddCustomerImage(customerImage);
            //        if (customerImage.IID > 0)
            //        {
            //            lblWarning.Text = "Data successfully saved...";
            //            lblWarning.ForeColor = System.Drawing.Color.Green;
            //        }
            //        else
            //        {
            //            lblWarning.Text = "Data not saved...";
            //            lblWarning.ForeColor = System.Drawing.Color.Red;
            //        }
            //    }
            //}
            //else
            //{
            //    lblWarning.Text = "Image not saved...click the checkbox ";
            //    lblWarning.ForeColor = System.Drawing.Color.Red;
            //}
            
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //using (LeasingFacade _facade = new LeasingFacade())
            //{

            //    CustomerImage customerImage = CreateCustomerImage();
            //    CustomerImage customerImageUpdate = _facade.GetCustomerImageByIID(customerImage.IID);
            //    customerImageUpdate.ImageLocation = lblImagePath.Text;
            //    customerImageUpdate.UpdateBy = Convert.ToInt64(Session["UserID"].ToString()); ;
            //    customerImageUpdate.Updatedate = DateTime.Now;
            //    if (customerImageUpdate != null)
            //    {
            //        _facade.UpdateCustomerImage(customerImageUpdate);
                    
            //        lblWarning.Text = "Data successfully updated...";
            //        lblWarning.ForeColor = System.Drawing.Color.Green;
            //    }
            //    else
            //    {
            //        lblWarning.Text = "Data not updated...";
            //        lblWarning.ForeColor = System.Drawing.Color.Red;
            //    }
            //}
            
        }

        ///////////////////////////(working)

        private void loadGridviewWithImage()
        {
            DataTable dt = new DataTable();

            string strQuery = "select * from CustomerImage order by IID";

            SqlCommand cmd = new SqlCommand(strQuery);
            SqlConnection con = new SqlConnection(@"Data Source=192.168.1.4;Initial Catalog=MeghnaSolar;User ID=sa;Password=dba@123");
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            try
            {
                con.Open();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

            finally
            {
                con.Close();
                sda.Dispose();
                con.Dispose();
            }
        }
        
        protected void btnUpload_Click(object sender, EventArgs e)
        {

            if (file.PostedFile != null)
            {
                string FileName = file.FileName; //Path.GetFileName(file.PostedFile.FileName);

                //Save files to disk

                file.SaveAs(Server.MapPath("~/Images/" + FileName));

                //Add Entry to DataBase               

                SqlConnection con = new SqlConnection(@"Data Source=192.168.1.4;Initial Catalog=MeghnaSolar;User ID=sa;Password=dba@123");
                string strQuery = "insert into CustomerImage (CustomerID,ImageLocation,CreateBy,CreateDate,UpdateBy,Updatedate,IsRemove)" + " values(@CustomerID,@ImageLocation,@CreateBy,@CreateDate,@UpdateBy,@Updatedate,@IsRemove)";

                SqlCommand cmd = new SqlCommand(strQuery);
                //cmd.Parameters.AddWithValue("@FileName", FileName);               
                
                cmd.Parameters.AddWithValue("@CustomerID", Convert.ToInt64(Session["UserID"]));                
                cmd.Parameters.AddWithValue("@ImageLocation", "/Images/" + FileName);
                cmd.Parameters.AddWithValue("@CreateBy", Convert.ToInt64(Session["UserID"]));
                cmd.Parameters.AddWithValue("@CreateDate", GeneralConfigurationFacade.GetServerDateTime());
                cmd.Parameters.AddWithValue("@UpdateBy", Convert.ToInt64(Session["UserID"]));
                cmd.Parameters.AddWithValue("@Updatedate", GeneralConfigurationFacade.GetServerDateTime());
                cmd.Parameters.AddWithValue("@IsRemove", "False");

                
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }

                finally
                {
                    con.Close();
                    con.Dispose();
                    loadGridviewWithImage();
                }

            }

        }        

        //////////////////////////(wprking)

        protected void BindGridView()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("Select IID,CustomerID,ImageLocation,CreateBy,CreateDate,UpdateBy,Updatedate,IsRemove from CustomerImage", con);
        con.Open();
        da.Fill(dt);
        con.Close();

        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
        // edit event
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindGridView();
    }
        // update event
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //find student id of edit row
        string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
        // find values for update
        TextBox name = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtImageLocation");
        FileUpload FileUpload1 = (FileUpload)GridView1.Rows[e.RowIndex].FindControl("FileUpload1");
        string path = "~/Images/";
        string ImageLocation = "/Images/" + FileUpload1.FileName;
        if (FileUpload1.HasFile)
        {
            path += FileUpload1.FileName;
            //save image in folder
            //FileUpload1.SaveAs(MapPath(path));
            FileUpload1.SaveAs(Server.MapPath("~/Images/" + FileUpload1.FileName));
        }
        else
        {
            // use previous user image if new image is not changed
            Image img = (Image)GridView1.Rows[e.RowIndex].FindControl("img_user");
            path = img.ImageUrl;
        }
        //IID,CustomerID,ImageLocation,CreateBy,CreateDate,UpdateBy,Updatedate,IsRemove
        SqlCommand cmd = new SqlCommand("update CustomerImage set ImageLocation='" + ImageLocation + "' where IID=" + id + "", con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        
        GridView1.EditIndex = -1;
        BindGridView();

    }
        // cancel edit event
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGridView();
        }

     }
}