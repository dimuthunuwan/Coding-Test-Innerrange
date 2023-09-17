using full_stack.Models;
using full_stack.Util.Classes;
using full_stack.Util.Interfaces;
using System.Xml.Linq;
using System.Linq;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;
using System.Collections.Generic;

namespace full_stack.Logic
{
    public class ValidateCSV
    {
        private readonly ICSVService _csvService;

        public ValidateCSV(ICSVService csvService) 
        {
            _csvService = csvService;
        }

        public List<Employee> Validate(IFormFile csvFile, IFormFile stateFile) 
        {
            List<Employee> Returnedemployees = new List<Employee>();

            try
            {
                List<Employee> employees = _csvService.ReadCSV<Employee>(csvFile.OpenReadStream(),true).ToList();
                
                List<State> states = _csvService.ReadCSV<State>(stateFile.OpenReadStream(),false).ToList();

                foreach(State state in states) 
                {
                    switch (state.Id) 
                    {
                        case 1:
                            state.PostCodes = AustralianPostCodes.TAS; 
                            break;

                        case 2:
                            state.PostCodes = AustralianPostCodes.VIC;
                            break;

                        case 3:
                            state.PostCodes = AustralianPostCodes.NSW;
                            break;

                        case 4:
                            state.PostCodes = AustralianPostCodes.ACT;
                            break;

                        case 5:
                            state.PostCodes = AustralianPostCodes.QLD;
                            break;

                        case 6:
                            state.PostCodes = AustralianPostCodes.NT;
                            break;

                        case 7:
                            state.PostCodes = AustralianPostCodes.SA;
                            break;

                        case 8:
                            state.PostCodes = AustralianPostCodes.WA;
                            break;
                    }
                }

                

               Returnedemployees = ValidateFields(employees, states);
            }
            
            catch(CsvHelper.ReaderException ex) 
            { 

            }
            catch (Exception)
            {

                throw;
            }
            return Returnedemployees;
        }

        private List<Employee> ValidateFields(List<Employee> employees, List<State> States)
        {
            //Boolean success = true;
            try
            {
                
                foreach (Employee employee in employees) 
                {
                    //********** Begin check employee name *********************************************

                    if(employee.Name != null && employee.Name != string.Empty) 
                    {
                        if(employee.Name.Length < 4)
                        {
                            employee.IsNameValid = false;
                        }
                    }

                    //********** End check employee name ***********************************************




                    //********** Begin check employee state ********************************************

                    if (employee.State > 0 && employee.State < 9)
                    {
                        var newList = States.Where(x => x.Id.Equals(employee.State)).ToList();

                        if (newList.Count == 0)
                            employee.IsStateValid = false;
                    }
                    else
                        employee.IsStateValid = false;

                    //********** End check employee state ***********************************************




                    //********** Begin check employee PostCode with state *******************************

                    if (employee.PostCode != null && employee.PostCode != string.Empty)
                    {
                        if (employee.IsStateValid == true)
                        {
                            var PostCoderange = States.Where(person => person.Id == employee.State).FirstOrDefault();

                            if (PostCoderange != null && PostCoderange.PostCodes != null) 
                            {
                                char[] delimiterChars = { '-', ',' };

                                string[] multiArray = PostCoderange.PostCodes.Split(delimiterChars);

                                for (int i = 0; i < multiArray.Length; i += 2)
                                {
                                    if(Convert.ToInt32(employee.PostCode) >= Convert.ToInt32(multiArray[i]) && Convert.ToInt32(employee.PostCode) <= Convert.ToInt32(multiArray[i + 1]))
                                    {
                                        employee.IsPostCodeBelongsToState = true;
                                        break;
                                    }
                                    else
                                        employee.IsPostCodeBelongsToState = false;
                                }
                            }
                            
                        }
                    }
                    else
                        employee.IsPostCodeExist = false;

                    //********** End check employee PostCode with state **************************************




                    //********** Begin check employee salary *************************************************

                    if (Convert.ToInt32(employee.Salary) < 0)
                        employee.IsSalaryValid = false;

                    //********** End check employee salary ***************************************************
                }

                return employees.Where(emp => emp.IsNameValid == false || emp.IsPostCodeBelongsToState == false || emp.IsPostCodeExist == false || emp.IsPostCodeValid == false || emp.IsSalaryValid == false || emp.IsStateValid == false).ToList();

            }
            catch (Exception)
            {

                throw;
            }
            //return success;
        }
    }
}
