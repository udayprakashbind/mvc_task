using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace mvc_task.Models
{
    public class DataServices
    {
        public SqlConnection con=new SqlConnection(ConfigurationManager.ConnectionStrings["myconn"].ConnectionString);



        #region manage subadmin
        public bool insert_subadmin(mvc_task.Models.manage_subadmin subadmin)
        {
            SqlCommand cmd = new SqlCommand("sp_SubAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SubAdminName", subadmin.SubAdminName);
            cmd.Parameters.AddWithValue("@Password", subadmin.Password);
            cmd.Parameters.AddWithValue("@MobileNo", subadmin.MobileNo);
            cmd.Parameters.AddWithValue("@SubAdminBranch", subadmin.SubAdminBranch);
            cmd.Parameters.AddWithValue("@Gender", subadmin.Gender);
            cmd.Parameters.AddWithValue("@Designation", subadmin.Designation);
            cmd.Parameters.AddWithValue("@DOB", subadmin.DOB);
            cmd.Parameters.AddWithValue("@JoinDate", subadmin.JoinDate);
            cmd.Parameters.AddWithValue("@Salary", subadmin.Salary);
            cmd.Parameters.AddWithValue("@Qualification", subadmin.Qualification);
            cmd.Parameters.AddWithValue("@AadharNo", subadmin.AadharNo);
            cmd.Parameters.AddWithValue("@PanNo", subadmin.PanNo);
            cmd.Parameters.AddWithValue("@StateName", subadmin.StateName);
            cmd.Parameters.AddWithValue("@StateCode", subadmin.StateCode);
            cmd.Parameters.AddWithValue("@CityName", subadmin.CityName);
            cmd.Parameters.AddWithValue("@CityCode", subadmin.CityCode);
            cmd.Parameters.AddWithValue("@Pincode", subadmin.Pincode);
            cmd.Parameters.AddWithValue("@Address", subadmin.Address);
            cmd.Parameters.AddWithValue("@File_Name", subadmin.File_Name);
            cmd.Parameters.AddWithValue("@File_Path", subadmin.File_Path);
            cmd.Parameters.AddWithValue("@Id", subadmin.id);
            if (subadmin.id != null && subadmin.id != "")
            {
                cmd.Parameters.AddWithValue("@Action", "updatesubadmin");
            }
            else
            {
                cmd.Parameters.AddWithValue("@Action", "insert_subadmin");

            }
            if (con.State == ConnectionState.Closed)
                con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public List<manage_subadmin> getsubadminlist()
        {
            List<manage_subadmin> subadmins = new List<manage_subadmin>();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_SubAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "getsubadminlist");
            SqlDataReader sdr = cmd.ExecuteReader();
            manage_subadmin sub = new manage_subadmin();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    sub = new manage_subadmin();
                    sub.id = sdr["Id"].ToString();
                    sub.SubAdminName = sdr["SubAdminName"].ToString();
                    sub.Password = sdr["Password"].ToString();
                    sub.MobileNo = sdr["MobileNo"].ToString();
                    sub.SubAdminBranch = sdr["SubAdminBranch"].ToString();
                    sub.Gender = sdr["Gender"].ToString();
                    sub.Designation = sdr["Designation"].ToString();
                    sub.DOB = sdr["DOB"].ToString();
                    sub.JoinDate = sdr["JoinDate"].ToString();
                    sub.Salary = sdr["Salary"].ToString();
                    sub.Qualification = sdr["Qualification"].ToString();
                    sub.AadharNo = sdr["AadharNo"].ToString();
                    sub.PanNo = sdr["PanNo"].ToString();
                    sub.StateName = sdr["StateName"].ToString();
                    sub.StateCode = sdr["StateCode"].ToString();
                    sub.CityName = sdr["CityName"].ToString();
                    sub.CityCode = sdr["CityCode"].ToString();
                    sub.Pincode = sdr["Pincode"].ToString();
                    sub.Address = sdr["Address"].ToString();
                    sub.File_Name = sdr["File_Name"].ToString();
                    sub.File_Path = sdr["File_Path"].ToString();
                    subadmins.Add(sub);
                }

            }
            con.Close();
            return subadmins;
        }

        public manage_subadmin getsubadminById(string id)
        {
            manage_subadmin sub = new manage_subadmin();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_SubAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "getsubadminbyId");
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                sub.id = sdr["Id"].ToString();
                sub.SubAdminName = sdr["SubAdminName"].ToString();
                sub.Password = sdr["Password"].ToString();
                sub.MobileNo = sdr["MobileNo"].ToString();
                sub.SubAdminBranch = sdr["SubAdminBranch"].ToString();
                sub.Gender = sdr["Gender"].ToString();
                sub.Designation = sdr["Designation"].ToString();
                sub.DOB = sdr["DOB"].ToString();
                sub.JoinDate = sdr["JoinDate"].ToString();
                sub.Salary = sdr["Salary"].ToString();
                sub.Qualification = sdr["Qualification"].ToString();
                sub.AadharNo = sdr["AadharNo"].ToString();
                sub.PanNo = sdr["PanNo"].ToString();
                sub.StateName = sdr["StateName"].ToString();
                sub.StateCode = sdr["StateCode"].ToString();
                sub.CityName = sdr["CityName"].ToString();
                sub.CityCode = sdr["CityCode"].ToString();
                sub.Pincode = sdr["Pincode"].ToString();
                sub.Address = sdr["Address"].ToString();
                sub.File_Name = sdr["File_Name"].ToString();
                sub.File_Path = sdr["File_Path"].ToString();
            }
            sdr.Close();
            con.Close();
            return sub;
        }
        public bool delete_subadmin(string id)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("sp_SubAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "deletesubadmin");
            cmd.Parameters.AddWithValue("@Id", id);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        #endregion

        #region manage sequence No
        public bool insert_sequence(mvc_task.Models.manage_sequence sequence)
        {
            SqlCommand cmd = new SqlCommand("sp_SequenceNo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Branch", sequence.Branch);
            cmd.Parameters.AddWithValue("@QuotationPrefixNo", sequence.QuotationPrefixNo);
            cmd.Parameters.AddWithValue("@QuotationNo", sequence.QuotationNo);
            cmd.Parameters.AddWithValue("@SaleBookPrefixNo", sequence.SaleBookPrefixNo);
            cmd.Parameters.AddWithValue("@SaleBookNo", sequence.SaleBookNo);
            cmd.Parameters.AddWithValue("@PIPrefixNo", sequence.PIPrefixNo);
            cmd.Parameters.AddWithValue("@PINo", sequence.PINo);
            cmd.Parameters.AddWithValue("@POPrefixNo", sequence.POPrefixNo);
            cmd.Parameters.AddWithValue("@PONo", sequence.PONo);
            cmd.Parameters.AddWithValue("@InvoicePrefixNo", sequence.InvoicePrefixNo);
            cmd.Parameters.AddWithValue("@InvoiceNo", sequence.InvoiceNo);
            cmd.Parameters.AddWithValue("@Id", sequence.id);
            if (sequence.id != null && sequence.id != "")
            {
                cmd.Parameters.AddWithValue("@Action", "updatesequence");
            }
            else
            {
                cmd.Parameters.AddWithValue("@Action", "insert_sequenceNo");
            }
            if (con.State == ConnectionState.Closed)
                con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<manage_sequence> get_sequence_list()
        {
            List<manage_sequence> sequences = new List<manage_sequence>();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_SequenceNo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "getAllsequenceno");
            SqlDataReader sdr = cmd.ExecuteReader();
            manage_sequence seq = new manage_sequence();
            while (sdr.Read())
            {
                seq = new manage_sequence();
                seq.id = sdr["Id"].ToString();
                seq.Branch = sdr["Branch"].ToString();
                seq.QuotationPrefixNo = sdr["QuotationPrefixNo"].ToString();
                seq.QuotationNo = sdr["QuotationNo"].ToString();
                seq.SaleBookPrefixNo = sdr["SaleBookPrefixNo"].ToString();
                seq.SaleBookNo = sdr["SaleBookNo"].ToString();
                seq.PIPrefixNo = sdr["PIPrefixNo"].ToString();
                seq.PINo = sdr["PINo"].ToString();
                seq.POPrefixNo = sdr["POPrefixNo"].ToString();
                seq.PONo = sdr["PONo"].ToString();
                seq.InvoicePrefixNo = sdr["InvoicePrefixNo"].ToString();
                seq.InvoiceNo = sdr["InvoiceNo"].ToString();
                sequences.Add(seq);
            }
            con.Close();
            return sequences;

        }

        public manage_sequence getsequenceById(string id)
        {
            manage_sequence seq = new manage_sequence();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_SequenceNo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "getsequencebyId");
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                seq.id = sdr["Id"].ToString();
                seq.Branch = sdr["Branch"].ToString();
                seq.QuotationPrefixNo = sdr["QuotationPrefixNo"].ToString();
                seq.QuotationNo = sdr["QuotationNo"].ToString();
                seq.SaleBookPrefixNo = sdr["SaleBookPrefixNo"].ToString();
                seq.SaleBookNo = sdr["SaleBookNo"].ToString();
                seq.PIPrefixNo = sdr["PIPrefixNo"].ToString();
                seq.PINo = sdr["PINo"].ToString();
                seq.POPrefixNo = sdr["POPrefixNo"].ToString();
                seq.PONo = sdr["PONo"].ToString();
                seq.InvoicePrefixNo = sdr["InvoicePrefixNo"].ToString();
                seq.InvoiceNo = sdr["InvoiceNo"].ToString();
            }
            sdr.Close();
            con.Close();
            return seq;
        }

        public bool delete_sequence(string id)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("sp_SequenceNo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "deletesequence");
            cmd.Parameters.AddWithValue("@Id", id);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region manage product master

        public bool insert_product(mvc_task.Models.manage_product products)
        {
            SqlCommand cmd = new SqlCommand("sp_ProductMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", products.id);
            cmd.Parameters.AddWithValue("@ProductName", products.ProductName);
            cmd.Parameters.AddWithValue("@OEM", products.OEM);
            cmd.Parameters.AddWithValue("@licenceNo", products.licenceNo);
            cmd.Parameters.AddWithValue("@PartNo", products.PartNo);
            cmd.Parameters.AddWithValue("@Price", products.Price);
            cmd.Parameters.AddWithValue("@HSNNo", products.HSNNo);
            cmd.Parameters.AddWithValue("@AMCPrice", products.AMCPrice);
            cmd.Parameters.AddWithValue("@Description", products.Description);
            cmd.Parameters.AddWithValue("@File_Path", products.File_Path);
            cmd.Parameters.AddWithValue("@File_Name", products.File_Name);
            if (products.id != null && products.id != "")
            {
                cmd.Parameters.AddWithValue("@Action", "updateproductbyId");

            }
            else
            {
                cmd.Parameters.AddWithValue("@Action", "insert_product");

            }
            if (con.State == ConnectionState.Closed)
                con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<manage_product> getproductlist()
        {
            List<manage_product> products = new List<manage_product>();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ProductMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "getAllproduct");
            SqlDataReader sdr = cmd.ExecuteReader();
            manage_product pro = new manage_product();
            while (sdr.Read())
            {
                pro = new manage_product();
                pro.id = sdr["Id"].ToString();
                pro.ProductName = sdr["ProductName"].ToString();
                pro.OEM = sdr["OEM"].ToString();
                pro.licenceNo = sdr["licenceNo"].ToString();
                pro.PartNo = sdr["PartNo"].ToString();
                pro.Price = sdr["Price"].ToString();
                pro.HSNNo = sdr["HSNNo"].ToString();
                pro.AMCPrice = sdr["AMCPrice"].ToString();
                pro.Description = sdr["Description"].ToString();
                pro.File_Path = sdr["File_Path"].ToString();
                pro.File_Name = sdr["File_Name"].ToString();
                products.Add(pro);
            }
            con.Close();
            return products;
        }

        public manage_product getproductbyId(string id)
        {
            manage_product pro = new manage_product();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ProductMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "getproductById");
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                pro.id = sdr["Id"].ToString();
                pro.ProductName = sdr["ProductName"].ToString();
                pro.OEM = sdr["OEM"].ToString();
                pro.licenceNo = sdr["licenceNo"].ToString();
                pro.PartNo = sdr["PartNo"].ToString();
                pro.Price = sdr["Price"].ToString();
                pro.HSNNo = sdr["HSNNo"].ToString();
                pro.AMCPrice = sdr["AMCPrice"].ToString();
                pro.Description = sdr["Description"].ToString();
                pro.File_Path = sdr["File_Path"].ToString();
                pro.File_Name = sdr["File_Name"].ToString();
            }
            sdr.Close();
            con.Close();
            return pro;
        }

        public bool delete_product(string id)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("sp_ProductMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "deleteproductbyId");
            cmd.Parameters.AddWithValue("@Id", id);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region manage vendor master

        public bool insert_vendor(mvc_task.Models.manage_vendor vendor)
        {
            SqlCommand cmd = new SqlCommand("sp_VendorMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", vendor.id);
            cmd.Parameters.AddWithValue("@VendoreName", vendor.VendoreName);
            cmd.Parameters.AddWithValue("@ContactPerson", vendor.ContactPerson);
            cmd.Parameters.AddWithValue("@ContactNO", vendor.ContactNO);
            cmd.Parameters.AddWithValue("@EmailId", vendor.EmailId);
            cmd.Parameters.AddWithValue("@StateName", vendor.StateName);
            cmd.Parameters.AddWithValue("@StateCode", vendor.StateCode);
            cmd.Parameters.AddWithValue("@CityName", vendor.CityName);
            cmd.Parameters.AddWithValue("@CityCode", vendor.CityCode);
            cmd.Parameters.AddWithValue("@Pincode", vendor.Pincode);
            cmd.Parameters.AddWithValue("@GSTNo", vendor.GSTNo);
            cmd.Parameters.AddWithValue("@PanNo", vendor.PanNo);
            cmd.Parameters.AddWithValue("@Address", vendor.Address);
            if (vendor.id != null && vendor.id != "")
            {
                cmd.Parameters.AddWithValue("@Action", "updateVendorbyId");

            }
            else
            {
                cmd.Parameters.AddWithValue("@Action", "insert_Vendor");

            }

            if (con.State == ConnectionState.Closed)
                con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<manage_vendor> getvendorlist()
        {
            List<manage_vendor> vendors = new List<manage_vendor>();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_VendorMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "getAllVendor");
            SqlDataReader sdr = cmd.ExecuteReader();
            manage_vendor ven = new manage_vendor();
            if (sdr.Read())
            {
                while (sdr.Read())
                {
                    ven = new manage_vendor();
                    ven.id = sdr["Id"].ToString();
                    ven.VendoreName = sdr["VendoreName"].ToString();
                    ven.ContactPerson = sdr["ContactPerson"].ToString();
                    ven.ContactNO = sdr["ContactNO"].ToString();
                    ven.EmailId = sdr["EmailId"].ToString();
                    ven.StateName = sdr["StateName"].ToString();
                    ven.StateCode = sdr["StateCode"].ToString();
                    ven.CityName = sdr["CityName"].ToString();
                    ven.CityCode = sdr["CityCode"].ToString();
                    ven.Pincode = sdr["Pincode"].ToString();
                    ven.GSTNo = sdr["GSTNo"].ToString();
                    ven.PanNo = sdr["PanNo"].ToString();
                    ven.Address = sdr["Address"].ToString();
                    vendors.Add(ven);
                }
            }
            sdr.Close();
            con.Close();
            return vendors;
        }

        public manage_vendor getvendorById(string id)
        {
            manage_vendor ven = new manage_vendor();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_VendorMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "getVendorbyId");
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();

                ven.id = sdr["Id"].ToString();
                ven.VendoreName = sdr["VendoreName"].ToString();
                ven.ContactPerson = sdr["ContactPerson"].ToString();
                ven.ContactNO = sdr["ContactNO"].ToString();
                ven.EmailId = sdr["EmailId"].ToString();
                ven.StateName = sdr["StateName"].ToString();
                ven.StateCode = sdr["StateCode"].ToString();
                ven.CityName = sdr["CityName"].ToString();
                ven.CityCode = sdr["CityCode"].ToString();
                ven.Pincode = sdr["Pincode"].ToString();
                ven.GSTNo = sdr["GSTNo"].ToString();
                ven.PanNo = sdr["PanNo"].ToString();
                ven.Address = sdr["Address"].ToString();
            }
            con.Close();
            return ven;
        }

        public bool delete_vendor(string id)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("sp_VendorMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "deleteVendorbyId");
            cmd.Parameters.AddWithValue("@Id", id);
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion

        #region manage sale book
        public bool insert_salebook(mvc_task.Models.manage_salebook salebook)
        {
            SqlCommand cmd = new SqlCommand("sp_SaleBook", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", salebook.id);
            cmd.Parameters.AddWithValue("@OrderNo", salebook.OrderNo);
            cmd.Parameters.AddWithValue("@QuotationReference", salebook.QuotationReference);
            cmd.Parameters.AddWithValue("@LeadReference", salebook.LeadReference);
            cmd.Parameters.AddWithValue("@Employee", salebook.Employee);
            cmd.Parameters.AddWithValue("@Branch", salebook.Branch);
            cmd.Parameters.AddWithValue("@SelectBillTO", salebook.SelectBillTO);
            cmd.Parameters.AddWithValue("@Date", salebook.Date);
            cmd.Parameters.AddWithValue("@SelectShipTO", salebook.SelectShipTO);
            cmd.Parameters.AddWithValue("@Add_PORNo", salebook.Add_PORNo);
            cmd.Parameters.AddWithValue("@LANID", salebook.LANID);
            cmd.Parameters.AddWithValue("@PromoCode", salebook.PromoCode);
            cmd.Parameters.AddWithValue("@DomainID", salebook.DomainID);
            cmd.Parameters.AddWithValue("@RenewalStatus", salebook.RenewalStatus);
            cmd.Parameters.AddWithValue("@RenewalPeriod", salebook.RenewalPeriod);
            cmd.Parameters.AddWithValue("@RenewalEndDate", salebook.RenewalEndDate);
            cmd.Parameters.AddWithValue("@RenewalCount", salebook.RenewalCount);
            cmd.Parameters.AddWithValue("@BillingStatus", salebook.BillingStatus);
            cmd.Parameters.AddWithValue("@BillingPeriod", salebook.BillingPeriod);
            cmd.Parameters.AddWithValue("@BillingEndDate", salebook.BillingEndDate);
            cmd.Parameters.AddWithValue("@BillingCount", salebook.BillingCount);
            cmd.Parameters.AddWithValue("@InState_OutState", salebook.InState_OutState);
            cmd.Parameters.AddWithValue("@Tax", salebook.Tax);
            cmd.Parameters.AddWithValue("@TAXAmount", salebook.TAXAmount);
            cmd.Parameters.AddWithValue("@PriceBeforeTAX", salebook.PriceBeforeTAX);
            cmd.Parameters.AddWithValue("@PriceAfterTAX", salebook.PriceAfterTAX);
            cmd.Parameters.AddWithValue("@SaleGeneratedDate", salebook.SaleGeneratedDate);

            if (salebook.id != null && salebook.id != "")
            {
                cmd.Parameters.AddWithValue("@Action", "updateSaleBookbyId");
            }
            else
            {
                cmd.Parameters.AddWithValue("@Action", "insert_SaleBook");

            }

            if (con.State == ConnectionState.Closed)
                con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<manage_salebook> getsalebooklist()
        {
            List<manage_salebook> salebooks = new List<manage_salebook>();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_SaleBook", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "getAllSaleBook");
            SqlDataReader sdr = cmd.ExecuteReader();
            manage_salebook book = new manage_salebook();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    book = new manage_salebook();
                    book.id = sdr["Id"].ToString();
                    book.OrderNo = sdr["OrderNo"].ToString();
                    book.QuotationReference = sdr["QuotationReference"].ToString();
                    book.LeadReference = sdr["LeadReference"].ToString();
                    book.Employee = sdr["Employee"].ToString();
                    book.Branch = sdr["Branch"].ToString();
                    book.SelectBillTO = sdr["SelectBillTO"].ToString();
                    book.Date = sdr["Date"].ToString();
                    book.SelectShipTO = sdr["SelectShipTO"].ToString();
                    book.Add_PORNo = sdr["Add_PORNo"].ToString();
                    book.LANID = sdr["LANID"].ToString();
                    book.PromoCode = sdr["PromoCode"].ToString();
                    book.DomainID = sdr["DomainID"].ToString();
                    book.RenewalStatus = sdr["RenewalStatus"].ToString();
                    book.RenewalPeriod = sdr["RenewalPeriod"].ToString();
                    book.RenewalEndDate = sdr["RenewalEndDate"].ToString();
                    book.RenewalCount = sdr["RenewalCount"].ToString();
                    book.BillingStatus = sdr["BillingStatus"].ToString();
                    book.BillingPeriod = sdr["BillingPeriod"].ToString();
                    book.BillingEndDate = sdr["BillingEndDate"].ToString();
                    book.BillingCount = sdr["BillingCount"].ToString();
                    book.InState_OutState = sdr["InState_OutState"].ToString();
                    book.Tax = sdr["Tax"].ToString();
                    book.TAXAmount = sdr["TAXAmount"].ToString();
                    book.PriceBeforeTAX = sdr["PriceBeforeTAX"].ToString();
                    book.PriceAfterTAX = sdr["PriceAfterTAX"].ToString();
                    book.SaleGeneratedDate = sdr["SaleGeneratedDate"].ToString();
                    book.SaleGeneratedDate = sdr["SaleGeneratedDate"].ToString();
                    salebooks.Add(book);

                }
            }
            sdr.Close();
            con.Close();
            return salebooks;

        }

        public manage_salebook getsalebookbyId(string id)
        {
            manage_salebook book = new manage_salebook();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_SaleBook", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "getSaleBookbyId");
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                book.id = sdr["Id"].ToString();
                book.OrderNo = sdr["OrderNo"].ToString();
                book.QuotationReference = sdr["QuotationReference"].ToString();
                book.LeadReference = sdr["LeadReference"].ToString();
                book.Employee = sdr["Employee"].ToString();
                book.Branch = sdr["Branch"].ToString();
                book.SelectBillTO = sdr["SelectBillTO"].ToString();
                book.Date = sdr["Date"].ToString();
                book.SelectShipTO = sdr["SelectShipTO"].ToString();
                book.Add_PORNo = sdr["Add_PORNo"].ToString();
                book.LANID = sdr["LANID"].ToString();
                book.PromoCode = sdr["PromoCode"].ToString();
                book.DomainID = sdr["DomainID"].ToString();
                book.RenewalStatus = sdr["RenewalStatus"].ToString();
                book.RenewalPeriod = sdr["RenewalPeriod"].ToString();
                book.RenewalEndDate = sdr["RenewalEndDate"].ToString();
                book.RenewalCount = sdr["RenewalCount"].ToString();
                book.BillingStatus = sdr["BillingStatus"].ToString();
                book.BillingPeriod = sdr["BillingPeriod"].ToString();
                book.BillingEndDate = sdr["BillingEndDate"].ToString();
                book.BillingCount = sdr["BillingCount"].ToString();
                book.InState_OutState = sdr["InState_OutState"].ToString();
                book.Tax = sdr["Tax"].ToString();
                book.TAXAmount = sdr["TAXAmount"].ToString();
                book.PriceBeforeTAX = sdr["PriceBeforeTAX"].ToString();
                book.PriceAfterTAX = sdr["PriceAfterTAX"].ToString();
                book.SaleGeneratedDate = sdr["SaleGeneratedDate"].ToString();
                book.SaleGeneratedDate = sdr["SaleGeneratedDate"].ToString();
            }
            con.Close();
            return book;
        }

        public bool delete_salebook(string id)
        {
            if (con.State == ConnectionState.Closed)

                con.Open();
            SqlCommand cmd = new SqlCommand("sp_SaleBook", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "deleteSaleBookbyId");
            cmd.Parameters.AddWithValue("@Id", id);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion


        #region manage PI
        public bool insert_PI(mvc_task.Models.manage_pi pi)
        {
            SqlCommand cmd = new SqlCommand("sp_PI", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PINo", pi.PINo);
            cmd.Parameters.AddWithValue("@OrderNo", pi.OrderNo);
            cmd.Parameters.AddWithValue("@QuotationReference", pi.QuotationReference);
            cmd.Parameters.AddWithValue("@LeadReference", pi.LeadReference);
            cmd.Parameters.AddWithValue("@Employee", pi.Employee);
            cmd.Parameters.AddWithValue("@Branch", pi.Branch);
            cmd.Parameters.AddWithValue("@SelectBillTO", pi.SelectBillTO);
            cmd.Parameters.AddWithValue("@Date", pi.Date);
            cmd.Parameters.AddWithValue("@SelectShipTO", pi.SelectShipTO);
            cmd.Parameters.AddWithValue("@Add_PORNo", pi.Add_PORNo);
            cmd.Parameters.AddWithValue("@LANID", pi.LANID);
            cmd.Parameters.AddWithValue("@PromoCode", pi.PromoCode);
            cmd.Parameters.AddWithValue("@DomainID", pi.DomainID);
            cmd.Parameters.AddWithValue("@RenewalStatus", pi.RenewalStatus);
            cmd.Parameters.AddWithValue("@RenewalPeriod", pi.RenewalPeriod);
            cmd.Parameters.AddWithValue("@RenewalEndDate", pi.RenewalEndDate);
            cmd.Parameters.AddWithValue("@RenewalCount", pi.RenewalCount);
            cmd.Parameters.AddWithValue("@BillingStatus", pi.BillingStatus);
            cmd.Parameters.AddWithValue("@BillingPeriod", pi.BillingPeriod);
            cmd.Parameters.AddWithValue("@BillingEndDate", pi.BillingEndDate);
            cmd.Parameters.AddWithValue("@BillingCount", pi.BillingCount);
            cmd.Parameters.AddWithValue("@InState_OutState", pi.InState_OutState);
            cmd.Parameters.AddWithValue("@Tax", pi.Tax);
            cmd.Parameters.AddWithValue("@TAXAmount", pi.TAXAmount);
            cmd.Parameters.AddWithValue("@PriceBeforeTAX", pi.PriceBeforeTAX);
            cmd.Parameters.AddWithValue("@PriceAfterTAX", pi.PriceAfterTAX);
            cmd.Parameters.AddWithValue("@SaleGeneratedDate", pi.SaleGeneratedDate);
            cmd.Parameters.AddWithValue("@Id", pi.id);

            if (pi.id != null && pi.id != "")
            {
                cmd.Parameters.AddWithValue("@Action", "updatePIbyId");
            }
            else
            {
                cmd.Parameters.AddWithValue("@Action", "insert_PI");

            }

            if (con.State == ConnectionState.Closed)
                con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<manage_pi> getPIlist()
        {
            List<manage_pi> pilist = new List<manage_pi>();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_PI", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "getAllPI");
            SqlDataReader sdr = cmd.ExecuteReader();
            manage_pi pi = new manage_pi();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    pi = new manage_pi();
                    pi.id = sdr["Id"].ToString();
                    pi.PINo = sdr["PINo"].ToString();
                    pi.OrderNo = sdr["OrderNo"].ToString();
                    pi.QuotationReference = sdr["QuotationReference"].ToString();
                    pi.LeadReference = sdr["LeadReference"].ToString();
                    pi.Employee = sdr["Employee"].ToString();
                    pi.Branch = sdr["Branch"].ToString();
                    pi.SelectBillTO = sdr["SelectBillTO"].ToString();
                    pi.Date = sdr["Date"].ToString();
                    pi.SelectShipTO = sdr["SelectShipTO"].ToString();
                    pi.Add_PORNo = sdr["Add_PORNo"].ToString();
                    pi.LANID = sdr["LANID"].ToString();
                    pi.PromoCode = sdr["PromoCode"].ToString();
                    pi.DomainID = sdr["DomainID"].ToString();
                    pi.RenewalStatus = sdr["RenewalStatus"].ToString();
                    pi.RenewalPeriod = sdr["RenewalPeriod"].ToString();
                    pi.RenewalEndDate = sdr["RenewalEndDate"].ToString();
                    pi.RenewalCount = sdr["RenewalCount"].ToString();
                    pi.BillingStatus = sdr["BillingStatus"].ToString();
                    pi.BillingPeriod = sdr["BillingPeriod"].ToString();
                    pi.BillingEndDate = sdr["BillingEndDate"].ToString();
                    pi.BillingCount = sdr["BillingCount"].ToString();
                    pi.InState_OutState = sdr["InState_OutState"].ToString();
                    pi.Tax = sdr["Tax"].ToString();
                    pi.TAXAmount = sdr["TAXAmount"].ToString();
                    pi.PriceBeforeTAX = sdr["PriceBeforeTAX"].ToString();
                    pi.PriceAfterTAX = sdr["PriceAfterTAX"].ToString();
                    pi.SaleGeneratedDate = sdr["SaleGeneratedDate"].ToString();
                    pi.SaleGeneratedDate = sdr["SaleGeneratedDate"].ToString();
                    pilist.Add(pi);

                }
            }
            sdr.Close();
            con.Close();
            return pilist;

        }

        public manage_pi getPIbyId(string id)
        {
            manage_pi pi = new manage_pi();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_PI", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "getPIbyId");
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                pi.id = sdr["Id"].ToString();
                pi.PINo = sdr["PINo"].ToString();
                pi.OrderNo = sdr["OrderNo"].ToString();
                pi.QuotationReference = sdr["QuotationReference"].ToString();
                pi.LeadReference = sdr["LeadReference"].ToString();
                pi.Employee = sdr["Employee"].ToString();
                pi.Branch = sdr["Branch"].ToString();
                pi.SelectBillTO = sdr["SelectBillTO"].ToString();
                pi.Date = sdr["Date"].ToString();
                pi.SelectShipTO = sdr["SelectShipTO"].ToString();
                pi.Add_PORNo = sdr["Add_PORNo"].ToString();
                pi.LANID = sdr["LANID"].ToString();
                pi.PromoCode = sdr["PromoCode"].ToString();
                pi.DomainID = sdr["DomainID"].ToString();
                pi.RenewalStatus = sdr["RenewalStatus"].ToString();
                pi.RenewalPeriod = sdr["RenewalPeriod"].ToString();
                pi.RenewalEndDate = sdr["RenewalEndDate"].ToString();
                pi.RenewalCount = sdr["RenewalCount"].ToString();
                pi.BillingStatus = sdr["BillingStatus"].ToString();
                pi.BillingPeriod = sdr["BillingPeriod"].ToString();
                pi.BillingEndDate = sdr["BillingEndDate"].ToString();
                pi.BillingCount = sdr["BillingCount"].ToString();
                pi.InState_OutState = sdr["InState_OutState"].ToString();
                pi.Tax = sdr["Tax"].ToString();
                pi.TAXAmount = sdr["TAXAmount"].ToString();
                pi.PriceBeforeTAX = sdr["PriceBeforeTAX"].ToString();
                pi.PriceAfterTAX = sdr["PriceAfterTAX"].ToString();
                pi.SaleGeneratedDate = sdr["SaleGeneratedDate"].ToString();
                pi.SaleGeneratedDate = sdr["SaleGeneratedDate"].ToString();
            }
            con.Close();
            return pi;
        }

        public bool delete_PI(string id)
        {
            if (con.State == ConnectionState.Closed)

                con.Open();
            SqlCommand cmd = new SqlCommand("sp_PI", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "deleteSaleBookbyId");
            cmd.Parameters.AddWithValue("@Id", id);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

    }
}