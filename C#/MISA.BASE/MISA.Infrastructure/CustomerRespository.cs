using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using MISA.ApplicationCore;

namespace MISA.Infrastructure
{
    public class CustomerRespository : BaseRespository<Customer>, ICustomerResponsitory
    {
    
    }
}
