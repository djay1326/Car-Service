using Bal;
using Dal;
using Dal.CustomModels;
using Dal.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Controllers
{
    public class DashboardsController : Controller
    {
        private readonly CarContext _DbContext;
        private readonly UserManager<Users> userManager;
        private readonly SignInManager<Users> signInManager;
        private readonly RoleManager<IdentityRole<int>> roleManager;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IUsersAccountServices _userAccountServices;
        public DashboardsController(CarContext DbContext, UserManager<Users> _userManager,
                                SignInManager<Users> _signInManager, RoleManager<IdentityRole<int>> _roleManager,
                                IWebHostEnvironment _webHostEnvironment, IUsersAccountServices userAccountServiecs,
                                IUsersAccountServices usersAccountServices)
        {
            _DbContext = DbContext;
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
            webHostEnvironment = _webHostEnvironment;
            _userAccountServices = usersAccountServices;
        }

        public IActionResult AdminDashboard()
        {
            int userId = int.Parse(userManager.GetUserId(User));
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("Server=DESKTOP-H353LBS;Database=Car;Trusted_Connection=True;MultipleActiveResultSets=true");
                con.Open();
                SqlCommand cmd = new SqlCommand("spAdminDashboard",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", userId);
                SqlDataReader reader = cmd.ExecuteReader();
                int col1 = 0, col2 = 0, col3 = 0;
                string col4 = string.Empty,col5 = string.Empty,col6 = string.Empty;
                while (reader.Read())
                {
                    col1 = Convert.ToInt32(reader["TotalGarages"]);
                    col2 = Convert.ToInt32(reader["TotalCustomers"]);
                    col3 = Convert.ToInt32(reader["TotalMechanics"]);
                    col4 = (string)reader["FirstTableValues"];
                    col5 = (string)reader["SecondTableValues"];
                    col6 = (string)reader["ThirdTableValues"];
                }

               
                CustomModelAdminDashboard adminDashboard = new CustomModelAdminDashboard();

                List<FirstTableValues> tableOneData = JsonConvert.DeserializeObject<List<FirstTableValues>>(col4);
                List<SecondTableValues> tableTwoData = JsonConvert.DeserializeObject<List<SecondTableValues>>(col5);
                List<ThirdTableValues> tableThreeData = JsonConvert.DeserializeObject<List<ThirdTableValues>>(col6);
                adminDashboard.FirstTableValues = tableOneData;
                adminDashboard.SecondTableValues = tableTwoData;
                adminDashboard.ThirdTableValues = tableThreeData;
                adminDashboard.CountOfGarages = col1;
                adminDashboard.TotalCustomers = col2;
                adminDashboard.TotalMechanics = col3;
                return View(adminDashboard);
            }
            catch(Exception e)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public IActionResult CustomerDashboard()
        {
            int userId = int.Parse(userManager.GetUserId(User));
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("Server=DESKTOP-H353LBS;Database=Car;Trusted_Connection=True;MultipleActiveResultSets=true");
                con.Open();
                SqlCommand cmd = new SqlCommand("spCustomerDashboard", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", userId);
                SqlDataReader reader = cmd.ExecuteReader();
                int col1 = 0, col2 = 0, col3 = 0;
                string col4 = string.Empty,col5 = string.Empty;
                while (reader.Read())
                {
                    col1 = Convert.ToInt32(reader["TotalAppointments"]);
                    col2 = Convert.ToInt32(reader["CompletedAppointments"]);
                    col3 = Convert.ToInt32(reader["PendingAppointments"]);
                    col4 = (string)reader["DataOfFirstTable"];
                    col5 = (string)reader["DataOfSecondTable"];
                }

                CustomModelsForCustomerDashboard customerDashboard = new CustomModelsForCustomerDashboard();
                List<DataOfFirstTable> tableoneData = JsonConvert.DeserializeObject<List<DataOfFirstTable>>(col4);
                List<DataOfSecondTable> tabletwoData = JsonConvert.DeserializeObject<List<DataOfSecondTable>>(col5);
                customerDashboard.TotalAppointments = col1;
                customerDashboard.CompletedAppointments = col2;
                customerDashboard.PendingAppointments = col3;
                customerDashboard.DataOfFirstTable = tableoneData;
                customerDashboard.DataOfSecondTable = tabletwoData;
                return View(customerDashboard);
            }
            catch(Exception e)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
            
        }

        public IActionResult MechanicDashboard()
        {
            int userId = int.Parse(userManager.GetUserId(User));
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("Server=DESKTOP-H353LBS;Database=Car;Trusted_Connection=True;MultipleActiveResultSets=true");
                con.Open();
                SqlCommand cmd = new SqlCommand("spMechanicDashboardUnion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", userId);
                SqlDataReader reader = cmd.ExecuteReader();
                string col1 = string.Empty, col2 = string.Empty, col3 = string.Empty;
                int col4 = 0, col5 = 0, col6 = 0, col7 = 0;
                int? col8 = null;
                
                while (reader.Read())
                {
                    col1 = (string)reader["FirstTableData"];
                    col2 = (string)reader["SecondTableData"];
                    col3 = (string)reader["ThirdTableData"];
                    col4 = Convert.ToInt32(reader["CountOfGarages"]);
                    //col5 = Convert.ToInt32(reader["AppointmentCount"]);
                    col6 = Convert.ToInt32(reader["AnnualIncomeTotal"]);
                    //col7 = Convert.ToInt32(reader["MonthlyIncomeTotal"]);
                    //if(col8 == null)
                    //{
                    //    col8 = 0;
                    //}
                    //else
                    //{
                    //    col8 = Convert.ToInt32(reader["WeeklyIncomeTotal"]);
                    //}

                }
  

                //string info = reader.Read() ? reader.GetString(0) : "";
                //int YearIncome = reader.Read() ? reader.GetInt32(3) : 0;

                CustomModelMechanicDashboard allThreeTableDetails = new CustomModelMechanicDashboard();
                List<FirstTableData> allData1 = JsonConvert.DeserializeObject<List<FirstTableData>>(col1);
                List<SecondTableData> allData2 = JsonConvert.DeserializeObject<List<SecondTableData>>(col2);
                List<ThirdTableData> allData3 = JsonConvert.DeserializeObject<List<ThirdTableData>>(col3);

                allThreeTableDetails.FirstTableData = allData1;
                allThreeTableDetails.SecondTableData = allData2;
                allThreeTableDetails.ThirdTableData = allData3;
                allThreeTableDetails.GarageCount = col4;
                //allThreeTableDetails.Appointments = col5;
                allThreeTableDetails.YearIncome = col6;
                //allThreeTableDetails.MonthIncome = col7;
                //allThreeTableDetails.WeekIncome = Convert.ToInt32(col8);
                return View(allThreeTableDetails);





                //UserDetails userDetails = new UserDetails();
                //userDetails.Name = allData.Select(m => m.UserName).ToList();
                //List<UserDetails> allData1 = JsonConvert.DeserializeObject<List<UserDetails>>(info);

                //List<MechanicDashboardData> FirstTable = new List<MechanicDashboardData>();
                //List<MechanicDashboardData> SecondTable = new List<MechanicDashboardData>();
                //List<MechanicDashboardData> ThirdTable = new List<MechanicDashboardData>();
                //foreach(var item in allData)
                //{
                //    if(item.servicestatus == 1)
                //    {
                //        FirstTable.Add(item);
                //    }
                //    else if (item.servicestatus == 2 || item.servicestatus == 4 || item.servicestatus == 5 || item.servicestatus == 6)
                //    {
                //        SecondTable.Add(item);
                //    }

                //    ThirdTable.Add(item);
                //    //ViewBag.GarageCount = Convert.ToInt32(item.countId);
                //}

                //ViewBag.YearIncome = Convert.ToInt32(item.sumAnnualPrice);
                //ViewBag.MonthIncome = Convert.ToInt32(item.sumMonthPrice);
                //try
                //{
                //    ViewBag.WeekIncome = Convert.ToInt32(item.sumWeekPrice);
                //}
                //catch
                //{
                //    ViewBag.WeekIncome = 0;
                //}
                //ViewBag.Appointments = Convert.ToInt32(item.countAppointments);

                //while()

                //MechanicDashboardData jsonvalues = JsonConvert.DeserializeObject<MechanicDashboardDataFirst>(reader.ToString);

                //while (AllDataRead.Read())
                //{
                //    MechanicDashboardData allDatas = new MechanicDashboardData();

                //    allDatas.Name = AllDataRead["UserName"].ToString();
                //    allDatas.AddressLine1 = AllDataRead["AddressLine1"].ToString();
                //    allDatas.AddressLine2 = AllDataRead["AddressLine2"].ToString();
                //    allDatas.City = AllDataRead["City"].ToString();
                //    allDatas.State = AllDataRead["State"].ToString();
                //    allDatas.Postal = AllDataRead["PostalCode"].ToString();
                //    allDatas.AppointmentId = Convert.ToInt32(AllDataRead["Id"]);
                //    allDatas.CarModel = AllDataRead["CarModel"].ToString();
                //    allDatas.CarName = AllDataRead["CarName"].ToString();
                //    allDatas.CarNumber = AllDataRead["CarNumber"].ToString();
                //    allDatas.status = Convert.ToInt32(AllDataRead["ServiceStatus"]);
                //    allDatas.GarageName = AllDataRead["GarageName"].ToString();
                //    allDatas.GarageAddress1 = AllDataRead["GarageAdd1"].ToString();
                //    allDatas.GarageAddress2 = AllDataRead["GarageAdd2"].ToString();
                //    allDatas.GarageCity = AllDataRead["GarageCity"].ToString();
                //    allDatas.GarageState = AllDataRead["GarageState"].ToString();
                //    allDatas.GaragePostal = AllDataRead["GaragePostalCode"].ToString();
                //    try
                //    {
                //        allDatas.ratings = Convert.ToDecimal(AllDataRead["Ratings"]);
                //    }
                //    catch
                //    {
                //        allDatas.ratings = 0;
                //    }
                //    try
                //    {
                //        allDatas.comments = AllDataRead["Comments"].ToString();
                //    }
                //    catch
                //    {
                //        allDatas.comments = "";
                //    }

                //    ViewBag.YearIncome = Convert.ToInt32(AllDataRead["sumAnnualPrice"]);
                //    ViewBag.MonthIncome = Convert.ToInt32(AllDataRead["sumMonthPrice"]);

                //    try
                //    {
                //        ViewBag.WeekIncome = Convert.ToInt32(AllDataRead["sumWeekPrice"]);
                //    }
                //    catch
                //    {
                //        ViewBag.WeekIncome = 0;
                //    }
                //    ViewBag.Appointments = Convert.ToInt32(AllDataRead["countAppointments"]);
                //    ViewBag.GarageCount = Convert.ToInt32(AllDataRead["countId"]);
                //    if (allDatas.status == 1)
                //    {
                //        FirstTable.Add(allDatas);
                //    }
                //    else if (allDatas.status == 2 || allDatas.status == 4 || allDatas.status == 5 || allDatas.status == 6)
                //    {
                //        SecondTable.Add(allDatas);
                //    }

                //    ThirdTable.Add(allDatas);

                //}

                //ViewBag.AllDataFromDatabase = FirstTable;
                //ViewBag.SecondTableDataFromDatabase = SecondTable;
                //ViewBag.ThirdTableDataCount = ThirdTable;
                //ViewBag.ThirdTableDataFromDatabase = ThirdTable.OrderByDescending(c => c.ratings).ToList();


                //using (reader) .OrderByDescending(c => c.ratings)
                //{

                //    reader.Read();
                //    ViewBag.GarageCount = reader.GetInt32(0);
                //    //reader.NextResult();
                //    //ViewBag.YearIncome = reader.GetInt32(0);
                //}

            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                con.Close();
            }

        }

        
    }
}
