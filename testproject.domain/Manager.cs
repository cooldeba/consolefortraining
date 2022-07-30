using System;
namespace testproject
{
public class Manager:Employee, IManager
{ 
    public Manager()
    {       
          base.Role = Role.Manager;   
    }
  
    public void ProcessAppraisal()
    {

    }

    public void ApproveRejectRequest()
    {

    }
  

    

   
} 
}