﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Data;

namespace HippoBilling.Domain.Practices
{
    public class NPIRecord : Entity
    {
        public string NPI { get; set; }
        public string Entity_Type_Code { get; set; }
        public string Replacement_NPI { get; set; }
        public string Employer_Identification_Number__EIN_ { get; set; }
        public string Provider_Organization_Name__Legal_Business_Name_ { get; set; }
        public string Provider_Last_Name__Legal_Name_ { get; set; }
        public string Provider_First_Name { get; set; }
        public string Provider_Middle_Name { get; set; }
        public string Provider_Name_Prefix_Text { get; set; }
        public string Provider_Name_Suffix_Text { get; set; }
        public string Provider_Credential_Text { get; set; }
        public string Provider_Other_Organization_Name { get; set; }
        public string Provider_Other_Organization_Name_Type_Code { get; set; }
        public string Provider_Other_Last_Name { get; set; }
        public string Provider_Other_First_Name { get; set; }
        public string Provider_Other_Middle_Name { get; set; }
        public string Provider_Other_Name_Prefix_Text { get; set; }
        public string Provider_Other_Name_Suffix_Text { get; set; }
        public string Provider_Other_Credential_Text { get; set; }
        public string Provider_Other_Last_Name_Type_Code { get; set; }
        public string Provider_First_Line_Business_Mailing_Address { get; set; }
        public string Provider_Second_Line_Business_Mailing_Address { get; set; }
        public string Provider_Business_Mailing_Address_City_Name { get; set; }
        public string Provider_Business_Mailing_Address_State_Name { get; set; }
        public string Provider_Business_Mailing_Address_Postal_Code { get; set; }
        public string Provider_Business_Mailing_Address_Country_Code__If_outside_U_S__ { get; set; }
        public string Provider_Business_Mailing_Address_Telephone_Number { get; set; }
        public string Provider_Business_Mailing_Address_Fax_Number { get; set; }
        public string Provider_First_Line_Business_Practice_Location_Address { get; set; }
        public string Provider_Second_Line_Business_Practice_Location_Address { get; set; }
        public string Provider_Business_Practice_Location_Address_City_Name { get; set; }
        public string Provider_Business_Practice_Location_Address_State_Name { get; set; }
        public string Provider_Business_Practice_Location_Address_Postal_Code { get; set; }
        public string Provider_Business_Practice_Location_Address_Country_Code__If_outside_U_S__ { get; set; }
        public string Provider_Business_Practice_Location_Address_Telephone_Number { get; set; }
        public string Provider_Business_Practice_Location_Address_Fax_Number { get; set; }
        public string Provider_Enumeration_Date { get; set; }
        public string Last_Update_Date { get; set; }
        public string NPI_Deactivation_Reason_Code { get; set; }
        public string NPI_Deactivation_Date { get; set; }
        public string NPI_Reactivation_Date { get; set; }
        public string Provider_Gender_Code { get; set; }
        public string Authorized_Official_Last_Name { get; set; }
        public string Authorized_Official_First_Name { get; set; }
        public string Authorized_Official_Middle_Name { get; set; }
        public string Authorized_Official_Title_or_Position { get; set; }
        public string Authorized_Official_Telephone_Number { get; set; }
        public string Healthcare_Provider_Taxonomy_Code_1 { get; set; }
        public string Provider_License_Number_1 { get; set; }
        public string Provider_License_Number_State_Code_1 { get; set; }
        public string Healthcare_Provider_Primary_Taxonomy_Switch_1 { get; set; }
        public string Healthcare_Provider_Taxonomy_Code_2 { get; set; }
        public string Provider_License_Number_2 { get; set; }
        public string Provider_License_Number_State_Code_2 { get; set; }
        public string Healthcare_Provider_Primary_Taxonomy_Switch_2 { get; set; }
        public string Healthcare_Provider_Taxonomy_Code_3 { get; set; }
        public string Provider_License_Number_3 { get; set; }
        public string Provider_License_Number_State_Code_3 { get; set; }
        public string Healthcare_Provider_Primary_Taxonomy_Switch_3 { get; set; }
        public string Healthcare_Provider_Taxonomy_Code_4 { get; set; }
        public string Provider_License_Number_4 { get; set; }
        public string Provider_License_Number_State_Code_4 { get; set; }
        public string Healthcare_Provider_Primary_Taxonomy_Switch_4 { get; set; }
        public string Healthcare_Provider_Taxonomy_Code_5 { get; set; }
        public string Provider_License_Number_5 { get; set; }
        public string Provider_License_Number_State_Code_5 { get; set; }
        public string Healthcare_Provider_Primary_Taxonomy_Switch_5 { get; set; }
        public string Healthcare_Provider_Taxonomy_Code_6 { get; set; }
        public string Provider_License_Number_6 { get; set; }
        public string Provider_License_Number_State_Code_6 { get; set; }
        public string Healthcare_Provider_Primary_Taxonomy_Switch_6 { get; set; }
        public string Healthcare_Provider_Taxonomy_Code_7 { get; set; }
        public string Provider_License_Number_7 { get; set; }
        public string Provider_License_Number_State_Code_7 { get; set; }
        public string Healthcare_Provider_Primary_Taxonomy_Switch_7 { get; set; }
        public string Healthcare_Provider_Taxonomy_Code_8 { get; set; }
        public string Provider_License_Number_8 { get; set; }
        public string Provider_License_Number_State_Code_8 { get; set; }
        public string Healthcare_Provider_Primary_Taxonomy_Switch_8 { get; set; }
        public string Healthcare_Provider_Taxonomy_Code_9 { get; set; }
        public string Provider_License_Number_9 { get; set; }
        public string Provider_License_Number_State_Code_9 { get; set; }
        public string Healthcare_Provider_Primary_Taxonomy_Switch_9 { get; set; }
        public string Healthcare_Provider_Taxonomy_Code_10 { get; set; }
        public string Provider_License_Number_10 { get; set; }
        public string Provider_License_Number_State_Code_10 { get; set; }
        public string Healthcare_Provider_Primary_Taxonomy_Switch_10 { get; set; }
        public string Healthcare_Provider_Taxonomy_Code_11 { get; set; }
        public string Provider_License_Number_11 { get; set; }
        public string Provider_License_Number_State_Code_11 { get; set; }
        public string Healthcare_Provider_Primary_Taxonomy_Switch_11 { get; set; }
        public string Healthcare_Provider_Taxonomy_Code_12 { get; set; }
        public string Provider_License_Number_12 { get; set; }
        public string Provider_License_Number_State_Code_12 { get; set; }
        public string Healthcare_Provider_Primary_Taxonomy_Switch_12 { get; set; }
        public string Healthcare_Provider_Taxonomy_Code_13 { get; set; }
        public string Provider_License_Number_13 { get; set; }
        public string Provider_License_Number_State_Code_13 { get; set; }
        public string Healthcare_Provider_Primary_Taxonomy_Switch_13 { get; set; }
        public string Healthcare_Provider_Taxonomy_Code_14 { get; set; }
        public string Provider_License_Number_14 { get; set; }
        public string Provider_License_Number_State_Code_14 { get; set; }
        public string Healthcare_Provider_Primary_Taxonomy_Switch_14 { get; set; }
        public string Healthcare_Provider_Taxonomy_Code_15 { get; set; }
        public string Provider_License_Number_15 { get; set; }
        public string Provider_License_Number_State_Code_15 { get; set; }
        public string Healthcare_Provider_Primary_Taxonomy_Switch_15 { get; set; }
        public string Other_Provider_Identifier_1 { get; set; }
        public string Other_Provider_Identifier_Type_Code_1 { get; set; }
        public string Other_Provider_Identifier_State_1 { get; set; }
        public string Other_Provider_Identifier_Issuer_1 { get; set; }
        public string Other_Provider_Identifier_2 { get; set; }
        public string Other_Provider_Identifier_Type_Code_2 { get; set; }
        public string Other_Provider_Identifier_State_2 { get; set; }
        public string Other_Provider_Identifier_Issuer_2 { get; set; }
        public string Other_Provider_Identifier_3 { get; set; }
        public string Other_Provider_Identifier_Type_Code_3 { get; set; }
        public string Other_Provider_Identifier_State_3 { get; set; }
        public string Other_Provider_Identifier_Issuer_3 { get; set; }
        public string Other_Provider_Identifier_4 { get; set; }
        public string Other_Provider_Identifier_Type_Code_4 { get; set; }
        public string Other_Provider_Identifier_State_4 { get; set; }
        public string Other_Provider_Identifier_Issuer_4 { get; set; }
        public string Other_Provider_Identifier_5 { get; set; }
        public string Other_Provider_Identifier_Type_Code_5 { get; set; }
        public string Other_Provider_Identifier_State_5 { get; set; }
        public string Other_Provider_Identifier_Issuer_5 { get; set; }
        public string Other_Provider_Identifier_6 { get; set; }
        public string Other_Provider_Identifier_Type_Code_6 { get; set; }
        public string Other_Provider_Identifier_State_6 { get; set; }
        public string Other_Provider_Identifier_Issuer_6 { get; set; }
        public string Other_Provider_Identifier_7 { get; set; }
        public string Other_Provider_Identifier_Type_Code_7 { get; set; }
        public string Other_Provider_Identifier_State_7 { get; set; }
        public string Other_Provider_Identifier_Issuer_7 { get; set; }
        public string Other_Provider_Identifier_8 { get; set; }
        public string Other_Provider_Identifier_Type_Code_8 { get; set; }
        public string Other_Provider_Identifier_State_8 { get; set; }
        public string Other_Provider_Identifier_Issuer_8 { get; set; }
        public string Other_Provider_Identifier_9 { get; set; }
        public string Other_Provider_Identifier_Type_Code_9 { get; set; }
        public string Other_Provider_Identifier_State_9 { get; set; }
        public string Other_Provider_Identifier_Issuer_9 { get; set; }
        public string Other_Provider_Identifier_10 { get; set; }
        public string Other_Provider_Identifier_Type_Code_10 { get; set; }
        public string Other_Provider_Identifier_State_10 { get; set; }
        public string Other_Provider_Identifier_Issuer_10 { get; set; }
        public string Other_Provider_Identifier_11 { get; set; }
        public string Other_Provider_Identifier_Type_Code_11 { get; set; }
        public string Other_Provider_Identifier_State_11 { get; set; }
        public string Other_Provider_Identifier_Issuer_11 { get; set; }
        public string Other_Provider_Identifier_12 { get; set; }
        public string Other_Provider_Identifier_Type_Code_12 { get; set; }
        public string Other_Provider_Identifier_State_12 { get; set; }
        public string Other_Provider_Identifier_Issuer_12 { get; set; }
        public string Other_Provider_Identifier_13 { get; set; }
        public string Other_Provider_Identifier_Type_Code_13 { get; set; }
        public string Other_Provider_Identifier_State_13 { get; set; }
        public string Other_Provider_Identifier_Issuer_13 { get; set; }
        public string Other_Provider_Identifier_14 { get; set; }
        public string Other_Provider_Identifier_Type_Code_14 { get; set; }
        public string Other_Provider_Identifier_State_14 { get; set; }
        public string Other_Provider_Identifier_Issuer_14 { get; set; }
        public string Other_Provider_Identifier_15 { get; set; }
        public string Other_Provider_Identifier_Type_Code_15 { get; set; }
        public string Other_Provider_Identifier_State_15 { get; set; }
        public string Other_Provider_Identifier_Issuer_15 { get; set; }
        public string Other_Provider_Identifier_16 { get; set; }
        public string Other_Provider_Identifier_Type_Code_16 { get; set; }
        public string Other_Provider_Identifier_State_16 { get; set; }
        public string Other_Provider_Identifier_Issuer_16 { get; set; }
        public string Other_Provider_Identifier_17 { get; set; }
        public string Other_Provider_Identifier_Type_Code_17 { get; set; }
        public string Other_Provider_Identifier_State_17 { get; set; }
        public string Other_Provider_Identifier_Issuer_17 { get; set; }
        public string Other_Provider_Identifier_18 { get; set; }
        public string Other_Provider_Identifier_Type_Code_18 { get; set; }
        public string Other_Provider_Identifier_State_18 { get; set; }
        public string Other_Provider_Identifier_Issuer_18 { get; set; }
        public string Other_Provider_Identifier_19 { get; set; }
        public string Other_Provider_Identifier_Type_Code_19 { get; set; }
        public string Other_Provider_Identifier_State_19 { get; set; }
        public string Other_Provider_Identifier_Issuer_19 { get; set; }
        public string Other_Provider_Identifier_20 { get; set; }
        public string Other_Provider_Identifier_Type_Code_20 { get; set; }
        public string Other_Provider_Identifier_State_20 { get; set; }
        public string Other_Provider_Identifier_Issuer_20 { get; set; }
        public string Other_Provider_Identifier_21 { get; set; }
        public string Other_Provider_Identifier_Type_Code_21 { get; set; }
        public string Other_Provider_Identifier_State_21 { get; set; }
        public string Other_Provider_Identifier_Issuer_21 { get; set; }
        public string Other_Provider_Identifier_22 { get; set; }
        public string Other_Provider_Identifier_Type_Code_22 { get; set; }
        public string Other_Provider_Identifier_State_22 { get; set; }
        public string Other_Provider_Identifier_Issuer_22 { get; set; }
        public string Other_Provider_Identifier_23 { get; set; }
        public string Other_Provider_Identifier_Type_Code_23 { get; set; }
        public string Other_Provider_Identifier_State_23 { get; set; }
        public string Other_Provider_Identifier_Issuer_23 { get; set; }
        public string Other_Provider_Identifier_24 { get; set; }
        public string Other_Provider_Identifier_Type_Code_24 { get; set; }
        public string Other_Provider_Identifier_State_24 { get; set; }
        public string Other_Provider_Identifier_Issuer_24 { get; set; }
        public string Other_Provider_Identifier_25 { get; set; }
        public string Other_Provider_Identifier_Type_Code_25 { get; set; }
        public string Other_Provider_Identifier_State_25 { get; set; }
        public string Other_Provider_Identifier_Issuer_25 { get; set; }
        public string Other_Provider_Identifier_26 { get; set; }
        public string Other_Provider_Identifier_Type_Code_26 { get; set; }
        public string Other_Provider_Identifier_State_26 { get; set; }
        public string Other_Provider_Identifier_Issuer_26 { get; set; }
        public string Other_Provider_Identifier_27 { get; set; }
        public string Other_Provider_Identifier_Type_Code_27 { get; set; }
        public string Other_Provider_Identifier_State_27 { get; set; }
        public string Other_Provider_Identifier_Issuer_27 { get; set; }
        public string Other_Provider_Identifier_28 { get; set; }
        public string Other_Provider_Identifier_Type_Code_28 { get; set; }
        public string Other_Provider_Identifier_State_28 { get; set; }
        public string Other_Provider_Identifier_Issuer_28 { get; set; }
        public string Other_Provider_Identifier_29 { get; set; }
        public string Other_Provider_Identifier_Type_Code_29 { get; set; }
        public string Other_Provider_Identifier_State_29 { get; set; }
        public string Other_Provider_Identifier_Issuer_29 { get; set; }
        public string Other_Provider_Identifier_30 { get; set; }
        public string Other_Provider_Identifier_Type_Code_30 { get; set; }
        public string Other_Provider_Identifier_State_30 { get; set; }
        public string Other_Provider_Identifier_Issuer_30 { get; set; }
        public string Other_Provider_Identifier_31 { get; set; }
        public string Other_Provider_Identifier_Type_Code_31 { get; set; }
        public string Other_Provider_Identifier_State_31 { get; set; }
        public string Other_Provider_Identifier_Issuer_31 { get; set; }
        public string Other_Provider_Identifier_32 { get; set; }
        public string Other_Provider_Identifier_Type_Code_32 { get; set; }
        public string Other_Provider_Identifier_State_32 { get; set; }
        public string Other_Provider_Identifier_Issuer_32 { get; set; }
        public string Other_Provider_Identifier_33 { get; set; }
        public string Other_Provider_Identifier_Type_Code_33 { get; set; }
        public string Other_Provider_Identifier_State_33 { get; set; }
        public string Other_Provider_Identifier_Issuer_33 { get; set; }
        public string Other_Provider_Identifier_34 { get; set; }
        public string Other_Provider_Identifier_Type_Code_34 { get; set; }
        public string Other_Provider_Identifier_State_34 { get; set; }
        public string Other_Provider_Identifier_Issuer_34 { get; set; }
        public string Other_Provider_Identifier_35 { get; set; }
        public string Other_Provider_Identifier_Type_Code_35 { get; set; }
        public string Other_Provider_Identifier_State_35 { get; set; }
        public string Other_Provider_Identifier_Issuer_35 { get; set; }
        public string Other_Provider_Identifier_36 { get; set; }
        public string Other_Provider_Identifier_Type_Code_36 { get; set; }
        public string Other_Provider_Identifier_State_36 { get; set; }
        public string Other_Provider_Identifier_Issuer_36 { get; set; }
        public string Other_Provider_Identifier_37 { get; set; }
        public string Other_Provider_Identifier_Type_Code_37 { get; set; }
        public string Other_Provider_Identifier_State_37 { get; set; }
        public string Other_Provider_Identifier_Issuer_37 { get; set; }
        public string Other_Provider_Identifier_38 { get; set; }
        public string Other_Provider_Identifier_Type_Code_38 { get; set; }
        public string Other_Provider_Identifier_State_38 { get; set; }
        public string Other_Provider_Identifier_Issuer_38 { get; set; }
        public string Other_Provider_Identifier_39 { get; set; }
        public string Other_Provider_Identifier_Type_Code_39 { get; set; }
        public string Other_Provider_Identifier_State_39 { get; set; }
        public string Other_Provider_Identifier_Issuer_39 { get; set; }
        public string Other_Provider_Identifier_40 { get; set; }
        public string Other_Provider_Identifier_Type_Code_40 { get; set; }
        public string Other_Provider_Identifier_State_40 { get; set; }
        public string Other_Provider_Identifier_Issuer_40 { get; set; }
        public string Other_Provider_Identifier_41 { get; set; }
        public string Other_Provider_Identifier_Type_Code_41 { get; set; }
        public string Other_Provider_Identifier_State_41 { get; set; }
        public string Other_Provider_Identifier_Issuer_41 { get; set; }
        public string Other_Provider_Identifier_42 { get; set; }
        public string Other_Provider_Identifier_Type_Code_42 { get; set; }
        public string Other_Provider_Identifier_State_42 { get; set; }
        public string Other_Provider_Identifier_Issuer_42 { get; set; }
        public string Other_Provider_Identifier_43 { get; set; }
        public string Other_Provider_Identifier_Type_Code_43 { get; set; }
        public string Other_Provider_Identifier_State_43 { get; set; }
        public string Other_Provider_Identifier_Issuer_43 { get; set; }
        public string Other_Provider_Identifier_44 { get; set; }
        public string Other_Provider_Identifier_Type_Code_44 { get; set; }
        public string Other_Provider_Identifier_State_44 { get; set; }
        public string Other_Provider_Identifier_Issuer_44 { get; set; }
        public string Other_Provider_Identifier_45 { get; set; }
        public string Other_Provider_Identifier_Type_Code_45 { get; set; }
        public string Other_Provider_Identifier_State_45 { get; set; }
        public string Other_Provider_Identifier_Issuer_45 { get; set; }
        public string Other_Provider_Identifier_46 { get; set; }
        public string Other_Provider_Identifier_Type_Code_46 { get; set; }
        public string Other_Provider_Identifier_State_46 { get; set; }
        public string Other_Provider_Identifier_Issuer_46 { get; set; }
        public string Other_Provider_Identifier_47 { get; set; }
        public string Other_Provider_Identifier_Type_Code_47 { get; set; }
        public string Other_Provider_Identifier_State_47 { get; set; }
        public string Other_Provider_Identifier_Issuer_47 { get; set; }
        public string Other_Provider_Identifier_48 { get; set; }
        public string Other_Provider_Identifier_Type_Code_48 { get; set; }
        public string Other_Provider_Identifier_State_48 { get; set; }
        public string Other_Provider_Identifier_Issuer_48 { get; set; }
        public string Other_Provider_Identifier_49 { get; set; }
        public string Other_Provider_Identifier_Type_Code_49 { get; set; }
        public string Other_Provider_Identifier_State_49 { get; set; }
        public string Other_Provider_Identifier_Issuer_49 { get; set; }
        public string Other_Provider_Identifier_50 { get; set; }
        public string Other_Provider_Identifier_Type_Code_50 { get; set; }
        public string Other_Provider_Identifier_State_50 { get; set; }
        public string Other_Provider_Identifier_Issuer_50 { get; set; }
        public string Is_Sole_Proprietor { get; set; }
        public string Is_Organization_Subpart { get; set; }
        public string Parent_Organization_LBN { get; set; }
        public string Parent_Organization_TIN { get; set; }
        public string Authorized_Official_Name_Prefix_Text { get; set; }
        public string Authorized_Official_Name_Suffix_Text { get; set; }
        public string Authorized_Official_Credential_Text { get; set; }
        public string Healthcare_Provider_Taxonomy_Group_1 { get; set; }
        public string Healthcare_Provider_Taxonomy_Group_2 { get; set; }
        public string Healthcare_Provider_Taxonomy_Group_3 { get; set; }
        public string Healthcare_Provider_Taxonomy_Group_4 { get; set; }
        public string Healthcare_Provider_Taxonomy_Group_5 { get; set; }
        public string Healthcare_Provider_Taxonomy_Group_6 { get; set; }
        public string Healthcare_Provider_Taxonomy_Group_7 { get; set; }
        public string Healthcare_Provider_Taxonomy_Group_8 { get; set; }
        public string Healthcare_Provider_Taxonomy_Group_9 { get; set; }
        public string Healthcare_Provider_Taxonomy_Group_10 { get; set; }
        public string Healthcare_Provider_Taxonomy_Group_11 { get; set; }
        public string Healthcare_Provider_Taxonomy_Group_12 { get; set; }
        public string Healthcare_Provider_Taxonomy_Group_13 { get; set; }
        public string Healthcare_Provider_Taxonomy_Group_14 { get; set; }
        public string Healthcare_Provider_Taxonomy_Group_15 { get; set; }


        private string _index = string.Empty;

        private string Index
        {
            get
            {
                if (string.IsNullOrEmpty(_index))
                {
                    var type = this.GetType();

                    var property = type.GetProperties()
                        .Where(x => x.Name.StartsWith("Healthcare_Provider_Primary_Taxonomy_Switch_"))
                        .FirstOrDefault(
                            x =>
                                "y".Equals(x.GetValue(this, null).ToString(), StringComparison.CurrentCultureIgnoreCase));

                    if (property != null)
                    {
                        _index = property.Name.Replace("Healthcare_Provider_Primary_Taxonomy_Switch_", "");
                    }
                }
                return _index;
            }
        }

        public string GetSpecialityCode()
        {
            var property = this.GetType().GetProperty("Healthcare_Provider_Taxonomy_Code_" + Index);

            return property == null ? string.Empty : property.GetValue(this, null).ToString();
        }

        public string GetLicenseNumber()
        {
            var property = this.GetType().GetProperty("Provider_License_Number_" + Index);

            return property == null ? string.Empty : property.GetValue(this, null).ToString();
        }

        public bool IsOrganization()
        {
            return this.Entity_Type_Code == "2";
        }
    }
}