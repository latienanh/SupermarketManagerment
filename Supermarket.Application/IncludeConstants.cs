﻿namespace Supermarket.Application
{
    public static class IncludeConstants
    {
        public static readonly string[] ProductIncludes = new string[] { "Categories", "VariantValues" };
        public static readonly string[] CustomerIncludes = new string[] { "MembershipType" };
        public static readonly string[] SaleIncludes = new string[] { "InvoiceDetails"   ,"Employee", "Customer" };
         
    }
}
