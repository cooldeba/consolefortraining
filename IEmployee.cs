using System;
using System.Collections.Generic;

public interface IEmployee
{
    IList<string> Messages {get; set;}
     delegate void Graduitycalcdeletegate(double gamount);
    string Name {get; set;}
    double Salary {get; set;}
    string UnitHR {get; set;}
    string Manager {get; set;}
    event EventHandler OnResigned;
    void PrintEmployeeInfo();  
    Role Role {get; set;}
    void Resign();

    void CalcGraduity(Graduitycalcdeletegate callback);
    
}