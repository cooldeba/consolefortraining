using System;
namespace testproject.domain
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