using System.Data.Entity.Migrations;
using System.Reflection;
using Castle.Components.DictionaryAdapter.Xml;
using HippoBilling.Core.Authorization;
using HippoBilling.Core.Infrastructure;
using HippoBilling.Domain.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Domain.Addresses;
using HippoBilling.Domain.Insurances;
using HippoBilling.Domain.Practices;
using Microsoft.Practices.ServiceLocation;

namespace HippoBilling.Data.EntityFramework.Initializers
{
    public class InitializeWhenDatabaseCreated : System.Data.Entity.CreateDatabaseIfNotExists<HippoBillingContext>
    {
        protected override void Seed(HippoBillingContext context)
        {
            InitUsers(context);
            InitStates(context);
            InitSpecialities(context);
            InitPermissionModules(context);
            InitServicePlaces(context);
            InitPolicyTypes(context);
            context.SaveChanges();
            base.Seed(context);
        }

        private void InitUsers(HippoBillingContext context)
        {
            context.Users.Add(new User()
            {
                Id = Guid.NewGuid(),
                Email = "shblyl@qq.com",
                Password = PasswordHasher.HashedPassword("1111111"),
                Role = Role.Admin,
                Active = true,
                Name = "Sun"
            });

            context.Users.Add(new User()
            {
                Id = Guid.NewGuid(),
                Email = "pkoukounas@hippocraticsolutions.com",
                Password = PasswordHasher.HashedPassword("hippo?123"),
                Role = Role.Admin,
                Active = true,
                Name = "Peter"
            });
        }

        private void InitStates(HippoBillingContext context)
        {
            context.States.AddOrUpdate(x => x.Code, new State[]
            {
                new State() {Name = "Alabama", UpperName = "ALABAMA", Code = "AL"},
                new State() {Name = "Alaska", UpperName = "ALASKA", Code = "AK"},
                new State() {Name = "Arizona", UpperName = "ARIZONA", Code = "AZ"},
                new State() {Name = "Arkansas", UpperName = "ARKANSAS", Code = "AR"},
                new State() {Name = "California", UpperName = "CALIFORNIA", Code = "CA"},
                new State() {Name = "Colorado", UpperName = "COLORADO", Code = "CO"},
                new State() {Name = "Connecticut", UpperName = "CONNECTICUT ", Code = "CT"},
                new State() {Name = "Delaware", UpperName = "DELAWARE", Code = "DE"},
                new State() {Name = "Florida", UpperName = "FLORIDA", Code = "FL"},
                new State() {Name = "Georgia", UpperName = "GEORGIA", Code = "GA"},
                new State() {Name = "Hawaii", UpperName = "HAWAII", Code = "HI"},
                new State() {Name = "Idaho", UpperName = "IDAHO", Code = "ID"},
                new State() {Name = "Illinois", UpperName = "ILLINOIS", Code = "IL"},
                new State() {Name = "Indiana", UpperName = "INDIANA", Code = "IN"},
                new State() {Name = "Iowa", UpperName = "IOWA", Code = "IA"},
                new State() {Name = "Kansas", UpperName = "KANSAS", Code = "KS"},
                new State() {Name = "Kentucky", UpperName = "KENTUCKY", Code = "KY"},
                new State() {Name = "Louisiana", UpperName = "LOUISIANA", Code = "LA"},
                new State() {Name = "Maine", UpperName = "MAINE", Code = "ME"},
                new State() {Name = "Maryland", UpperName = "MARYLAND", Code = "MD"},
                new State() {Name = "Massachusetts", UpperName = "MASSACHUSETTS", Code = "MA"},
                new State() {Name = "Michigan", UpperName = "MICHIGAN", Code = "MI"},
                new State() {Name = "Minnesota", UpperName = "MINNESOTA", Code = "MN"},
                new State() {Name = "Mississippi", UpperName = "MISSISSIPPI", Code = "MS"},
                new State() {Name = "Missouri", UpperName = "MISSOURI", Code = "MO"},
                new State() {Name = "Montana", UpperName = "MONTANA", Code = "MT"},
                new State() {Name = "Nebraska", UpperName = "NEBRASKA", Code = "NE"},
                new State() {Name = "Nevada", UpperName = "NEVADA", Code = "NV"},
                new State() {Name = "New Hampshire", UpperName = "NEW HAMPSHIRE", Code = "NH"},
                new State() {Name = "New Jersey", UpperName = "NEW JERSEY", Code = "NJ"},
                new State() {Name = "New Mexico", UpperName = "NEW MEXICO", Code = "NM"},
                new State() {Name = "New York", UpperName = "NEW YORK", Code = "NY"},
                new State() {Name = "North Carolina", UpperName = "NORTH CAROLINA", Code = "NC"},
                new State() {Name = "North Dakota", UpperName = "NORTH DAKOTA", Code = "ND"},
                new State() {Name = "Ohio", UpperName = "OHIO", Code = "OH"},
                new State() {Name = "Oklahoma", UpperName = "OKLAHOMA", Code = "OK"},
                new State() {Name = "Oregon", UpperName = "OREGON", Code = "OR"},
                new State() {Name = "Pennsylvania", UpperName = "PENNSYLVANIA", Code = "PA"},
                new State() {Name = "Rhode Island", UpperName = "RHODE ISLAND", Code = "RI"},
                new State() {Name = "South Carolina", UpperName = "SOUTH CAROLINA", Code = "SC"},
                new State() {Name = "South Dakota", UpperName = "SOUTH DAKOTA", Code = "SD"},
                new State() {Name = "Tennessee", UpperName = "TENNESSEE", Code = "TN"},
                new State() {Name = "Texas", UpperName = "TEXAS", Code = "TX"},
                new State() {Name = "Utah", UpperName = "UTAH", Code = "UT"},
                new State() {Name = "Vermont", UpperName = "VERMONT", Code = "VT"},
                new State() {Name = "Virginia", UpperName = "VIRGINIA", Code = "VA"},
                new State() {Name = "Washington", UpperName = "WASHINGTON", Code = "WA"},
                new State() {Name = "West Virginia", UpperName = "WEST VIRGINIA", Code = "WV"},
                new State() {Name = "Wisconsin", UpperName = "WISCONSIN", Code = "WI"},
                new State() {Name = "Wyoming", UpperName = "WYOMING", Code = "WY"}
            });
        }

        private void InitSpecialities(HippoBillingContext context)
        {
            context.Specialities.AddOrUpdate(x => x.Code, new Speciality[]
            {
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Adolescent Medicine",
                    Code = "207QA0000X",
                    Description = "Physicians/Allopathic/Osteopathic/Family Practice/Adolescent Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Adolescent Medicine",
                    Code = "207RA0000X",
                    Description = "Physicians/Allopathic/Osteopathic/Internal Medicine/Adolescent Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Adolescent Medicine",
                    Code = "2080A0000X",
                    Description = "Physicians/Allopathic/Osteopathic/Pediatrics/Adolescent Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Aerospace Medicine",
                    Code = "2083A0100X",
                    Description =
                        "Physicians/Allopathic/Osteopathic/Preventive & Occupational Medicine/Aerospace Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Allergy",
                    Code = "207K00000X",
                    Description = "Physicians/Allopathic/Osteopathic/Allergy & Immunology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Allergy",
                    Code = "207KA0200X",
                    Description = "Physicians/Allopathic/Osteopathic/Allergy & Immunology/Allergy"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Allergy",
                    Code = "207KI0005X",
                    Description =
                        "Physicians/Allopathic/Osteopathic/Allergy & Immunology/Clinical & Laboratory Immunology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Allergy",
                    Code = "207RA0201X",
                    Description = "Physicians/Allopathic/Osteopathic/Internal Medicine/Allergy & Immunology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Anesthesiology",
                    Code = "207L00000X",
                    Description = "Physicians/Allopathic/Osteopathic/Anesthesiology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Anesthesiology",
                    Code = "207LA0401X",
                    Description = "Physicians/Allopathic/Osteopathic/Anesthesiology/Addiction Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Anesthesiology",
                    Code = "207LP2900X",
                    Description = "Physicians/Allopathic/Osteopathic/Anesthesiology/Pain Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Anesthesiology",
                    Code = "208VP0014X",
                    Description = "Physicians/Allopathic/Osteopathic/Pain Medicine/Interventional Pain Management"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Anesthesiology",
                    Code = "367500000X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Nurse Anesthetist/Certified Registered"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Anesthesiology",
                    Code = "367H00000X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Anesthesiologist Assistant"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Audiology",
                    Code = "231H00000X",
                    Description = "Speech, Language and Hearing Service Providers/Audiologist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Audiology",
                    Code = "231HA2400X",
                    Description =
                        "Speech, Language and Hearing Service Providers/Audiologist/Assistive Technology Practitioner"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Audiology",
                    Code = "231HA2500X",
                    Description =
                        "Speech, Language and Hearing Service Providers/Audiologist/Assistive Technology Supplier"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cardiology",
                    Code = "207RC0000X",
                    Description = "Physicians/Allopathic/Osteopathic/Internal Medicine/Cardiovascular Disease"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cardiology",
                    Code = "207RC0001X",
                    Description =
                        "Physicians/Allopathic/Osteopathic/Internal Medicine/Clinical Cardiac Electrophysiology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cardiology",
                    Code = "207RI0011X",
                    Description = "Physicians/Allopathic/Osteopathic/Internal Medicine/Interventional Cardiology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cardiology",
                    Code = "246W00000X",
                    Description = "Technologists, Technicians & Other Technical Service Providers/Technician/Cardiology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cardiology",
                    Code = "246X00000X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Specialist/Technologist Cardiovascular"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cardiology",
                    Code = "246XC1301X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Specialist/Technologist Cardiovascular/Sonography"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cardiology",
                    Code = "246XC2901X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Specialist/Technologist Cardiovascular/Cardiovascular Invasive Specialist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cardiology",
                    Code = "246ZE0500X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Specialist/Technologist/Other/EEG"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Community Health",
                    Code = "163WC1500X",
                    Description = "Nursing Service Providers/Registered Nurse/Community Health"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Community Health",
                    Code = "363LC1500X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner/Community Health"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Community Health",
                    Code = "364SC1501X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist/Community Health/Public Health"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Critical Care Medicine",
                    Code = "163WC0200X",
                    Description = "Nursing Service Providers/Registered Nurse/Critical Care Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Critical Care Medicine",
                    Code = "207LC0200X",
                    Description = "Physicians/Allopathic/Osteopathic/Anesthesiology/Critical Care Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Critical Care Medicine",
                    Code = "207RC0200X",
                    Description = "Physicians/Allopathic/Osteopathic/Internal Medicine/Critical Care Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Critical Care Medicine",
                    Code = "2086S0102X",
                    Description = "Physicians/Allopathic/Osteopathic/Surgery/Surgical Critical Care"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Critical Care Medicine",
                    Code = "363LA2100X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner/Acute Care"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Critical Care Medicine",
                    Code = "363LC0200X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner/Critical Care Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Critical Care Medicine",
                    Code = "363LP0222X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner/Pediatrics/Critical Care"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Critical Care Medicine",
                    Code = "364SA2100X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist/Acute Care"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Critical Care Medicine",
                    Code = "364SC0200X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist/Critical Care Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Dental",
                    Code = "122300000X",
                    Description = "Dental Service Providers/Dentist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Dental",
                    Code = "1223D0001X",
                    Description = "Dental Service Providers/Dentist/Dental Public Health"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Dental",
                    Code = "1223E0200X",
                    Description = "Dental Service Providers/Dentist/Endodontics"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Dental",
                    Code = "1223G0001X",
                    Description = "Dental Service Providers/Dentist/General Practice"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Dental",
                    Code = "1223P0106X",
                    Description = "Dental Service Providers/Dentist/Oral & Maxillofacial Pathology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Dental",
                    Code = "1223P0221X",
                    Description = "Dental Service Providers/Dentist/Pediatric Dentistry"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Dental",
                    Code = "1223P0300X",
                    Description = "Dental Service Providers/Dentist/Periodontics"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Dental",
                    Code = "1223P0700X",
                    Description = "Dental Service Providers/Dentist/Prosthodontics"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Dental",
                    Code = "1223S0112X",
                    Description = "Dental Service Providers/Dentist/Oral & Maxillofacial Surgery"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Dental",
                    Code = "1223X0008X",
                    Description = "Dental Service Providers/Dentist/Oral & Maxillofacial Radiology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Dental",
                    Code = "1223X0400X",
                    Description = "Dental Service Providers/Dentist/Orthodontics & Dentofacial Orthopedics"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Dental",
                    Code = "122400000X",
                    Description = "Dental Service Providers/Denturist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Dental",
                    Code = "124Q00000X",
                    Description = "Dental Service Providers/Dental Hygienist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Dental",
                    Code = "126800000X",
                    Description = "Dental Service Providers/Dental Assistant"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Dental",
                    Code = "126900000X",
                    Description = "Dental Service Providers/Dental Laboratory Technician"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Dental",
                    Code = "132700000X",
                    Description = "Dietary & Nutritional Service Providers/Dietary Manager"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Dermatology",
                    Code = "207N00000X",
                    Description = "Physicians/Allopathic/Osteopathic/Dermatology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Dermatology",
                    Code = "207ND0101X",
                    Description = "Physicians/Allopathic/Osteopathic/Dermatology/MOHS-Micrographic Surgery"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Dermatology",
                    Code = "207ND0900X",
                    Description = "Physicians/Allopathic/Osteopathic/Dermatology/Dermatopathology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Dermatology",
                    Code = "207NI0002X",
                    Description =
                        "Physicians/Allopathic/Osteopathic/Dermatology/Clinical & Laboratory Dermatological Immunology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Dermatology",
                    Code = "207NS0135X",
                    Description = "Physicians/Allopathic/Osteopathic/Dermatology/Dermatological Surgery"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Dermatology",
                    Code = "207Practicioner0225X",
                    Description = "Physicians/Allopathic/Osteopathic/Dermatology/Pediatric Dermatology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Dietetics",
                    Code = "133V00000X",
                    Description = "Dietary & Nutritional Service Providers/Dietician, Registered"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Dietetics",
                    Code = "136A00000X",
                    Description = "Dietary & Nutritional Service Providers/Dietetic Technician, Registered"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Emergency Medicine",
                    Code = "146D00000X",
                    Description = "Emergency Medical Service Providers/Personal Emergency Response Attendant"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Emergency Medicine",
                    Code = "146L00000X",
                    Description = "Emergency Medical Service Providers/Emergency Medical Technician, Paramedic"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Emergency Medicine",
                    Code = "146M00000X",
                    Description = "Emergency Medical Service Providers/Emergency Medical Technician, Intermediate"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Emergency Medicine",
                    Code = "146N00000X",
                    Description = "Emergency Medical Service Providers/Emergency Medical Technician, Basic"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Emergency Medicine",
                    Code = "163WE0003X",
                    Description = "Nursing Service Providers/Registered Nurse/Emergency"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Emergency Medicine",
                    Code = "207P00000X",
                    Description = "Physicians/Allopathic/Osteopathic/Emergency Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Emergency Medicine",
                    Code = "207PE0004X",
                    Description = "Physicians/Allopathic/Osteopathic/Emergency Medicine/Emergency Medical Services"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Emergency Medicine",
                    Code = "207PP0204X",
                    Description = "Physicians/Allopathic/Osteopathic/Emergency Medicine/Pediatric Emergency Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Emergency Medicine",
                    Code = "207PS0010X",
                    Description = "Physicians/Allopathic/Osteopathic/Emergency Medicine/Sports Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Emergency Medicine",
                    Code = "207PT0002X",
                    Description = "Physicians/Allopathic/Osteopathic/Emergency Medicine/Medical Toxicology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Emergency Medicine",
                    Code = "364SE0003X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist/Emergency"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Endocrinology",
                    Code = "207RE0101X",
                    Description =
                        "Physicians/Allopathic/Osteopathic/Internal Medicine/Endocrinology/Diabetes & Metabolism"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Endocrinology",
                    Code = "2080P0205X",
                    Description = "Physicians/Allopathic/Osteopathic/Pediatrics/Pediatric Endocrinology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Family Practice/Primary Care",
                    Code = "111N00000X",
                    Description = "Chiropractors/Chiropractor"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Family Practice/Primary Care",
                    Code = "111NT0100X",
                    Description = "Chiropractors/Chiropractor/Thermography"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Family Practice/Primary Care",
                    Code = "207Q00000X",
                    Description = "Physicians/Allopathic/Osteopathic/Family Practice"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Family Practice/Primary Care",
                    Code = "207QS0010X",
                    Description = "Physicians/Allopathic/Osteopathic/Family Practice/Sports Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Family Practice/Primary Care",
                    Code = "363LF0000X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner/Family"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Family Practice/Primary Care",
                    Code = "363LP2300X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner/Primary Care"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Family Practice/Primary Care",
                    Code = "364SF0001X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist/Family Health"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Gastroenterology",
                    Code = "163WG0100X",
                    Description = "Nursing Service Providers/Registered Nurse/Gastroenterology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Gastroenterology",
                    Code = "207RG0100X",
                    Description = "Physicians/Allopathic/Osteopathic/Internal Medicine/Gastroenterology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Gastroenterology",
                    Code = "2080P0206X",
                    Description = "Physicians/Allopathic/Osteopathic/Pediatrics/Pediatric Gastroenterology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "171100000X",
                    Description = "Other Service Providers/Acupuncturist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "171W00000X",
                    Description = "Other Service Providers/Contractor"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "172A00000X",
                    Description = "Other Service Providers/Driver"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "173000000X",
                    Description = "Other Service Providers/Legal Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "174400000X",
                    Description = "Other Service Providers/Specialist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "1744G0900X",
                    Description = "Other Service Providers/Specialist/Graphics Designer"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "1744R1102X",
                    Description = "Other Service Providers/Specialist/Research Study"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "1744R1103X",
                    Description = "Other Service Providers/Specialist/Research Data Abstracter/Coder"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "175F00000X",
                    Description = "Other Service Providers/Naturopath"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "175L00000X",
                    Description = "Other Service Providers/Homeopath"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "176P00000X",
                    Description = "Other Service Providers/Funeral Director"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "177F00000X",
                    Description = "Other Service Providers/Lodging"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "183500000X",
                    Description = "Pharmacy Service Providers/Pharmacist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "1835G0000X",
                    Description = "Pharmacy Service Providers/Pharmacist/General Practice"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "1835P1200X",
                    Description = "Pharmacy Service Providers/Pharmacist/Pharmacotherapy"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "1835P1300X",
                    Description = "Pharmacy Service Providers/Pharmacist/Psychopharmacy"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "183700000X",
                    Description = "Pharmacy Service Providers/Pharmacy Technician"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "207QA0401X",
                    Description = "Physicians/Allopathic/Osteopathic/Family Practice/Addiction Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "207QA0505X",
                    Description = "Physicians/Allopathic/Osteopathic/Family Practice/Adult Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "208D00000X",
                    Description = "Physicians/Allopathic/Osteopathic/General Practice"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "208U00000X",
                    Description = "Physicians/Allopathic/Osteopathic/Clinical Pharmacology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "209800000X",
                    Description = "Physicians/Allopathic/Osteopathic/Legal Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "246YC3301X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Specialist/Technologist/Health Information"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "246YC3302X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Specialist/Technologist/Health Information/Coding Specialist/Physician Office Based"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "246YC3302X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Specialist/Technologist/Health Information/Coding Specialist/Hospital Based"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "246Z00000X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Specialist/Technologist/Other"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "246ZA2600X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Specialist/Technologist/Other"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "246ZB0301X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Specialist/Technologist/Other/Art, Medical"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "246ZB0302X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Specialist/Technologist/Other/Biomedical Photographer"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "246ZB0600X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Specialist/Technologist/Other/Biostatistician"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "246ZG0701X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Specialist/Technologist/Other/Graphics Methods"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "246ZI1000X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Specialist/Technologist/Other/Illustration/Medical"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "247000000X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Technician/Health Information"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "2470A2800X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Technician/Health Information/Assistant Record Technician"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "2471Q0001X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Radiologic Technologist/Quality Management"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "247200000X",
                    Description = "Technologists, Technicians & Other Technical Service Providers/Technician/Other"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "2472B0301X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Specialist/Technologist/Other/Biomedical Engineering"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "2472B0301X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Technician/Other/Biomedical Engineering"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "2472D0500X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Technician/Other/Darkroom"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "2472V0600X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Technician/Other/Veterinary"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "363A00000X",
                    Description = "Physician Assistants & Advanced Practice Nursing Providers/Physician Assistant"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "363AM0700X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Physician Assistant/Medical"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "363L00000X",
                    Description = "Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "363LS0200X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner/School"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "363LW0102X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner/Women's Health"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "364SE1400X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist/Ethics"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "364SH0200X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist/Home Health"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "364SH1100X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist/Holistic"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "364SI0800X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist/Informatics"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "364SL0600X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist/Long-Term Care"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "364SS0200X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist/School"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "General Medicine",
                    Code = "364SW0102X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist/Women's Health"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Gerontology/Geriatrics",
                    Code = "163WG0600X",
                    Description = "Nursing Service Providers/Registered Nurse/Gerontology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Gerontology/Geriatrics",
                    Code = "207QG0300X",
                    Description = "Physicians/Allopathic/Osteopathic/Family Practice/Geriatric Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Gerontology/Geriatrics",
                    Code = "207RC0300X",
                    Description = "Physicians/Allopathic/Osteopathic/Internal Medicine/Geriatric Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Gerontology/Geriatrics",
                    Code = "363LG0600X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner/Gerontology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Gerontology/Geriatrics",
                    Code = "364SG0600X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist/Gerontology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Gynecology",
                    Code = "163WR1000X",
                    Description = "Nursing Service Providers/Registered Nurse/Reproductive Endocrinology/Infertility"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Gynecology",
                    Code = "207V00000X",
                    Description =
                        "Physicians/Allopathic/Osteopathic/Obstetrics & Gynecology/Reproductive Endocrinology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Gynecology",
                    Code = "207VG0400X",
                    Description = "Physicians/Allopathic/Osteopathic/Obstetrics & Gynecology/Gynecology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Gynecology",
                    Code = "207VX0201X",
                    Description = "Physicians/Allopathic/Osteopathic/Obstetrics & Gynecology/Gynecologic Oncology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Hematology",
                    Code = "207RH0000X",
                    Description = "Physicians/Allopathic/Osteopathic/Internal Medicine/Hematology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Hyperbaric Medicine",
                    Code = "207PE0005X",
                    Description = "Physicians/Allopathic/Osteopathic/Emergency Medicine/Undersea & Hyperbaric Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Hyperbaric Medicine",
                    Code = "2083P0011X",
                    Description =
                        "Physicians/Allopathic/Osteopathic/Preventive & Occupational Medicine/Preventive Medicine/Undersea and Hyperbaric Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Immunology",
                    Code = "207RI0001X",
                    Description =
                        "Physicians/Allopathic/Osteopathic/Internal Medicine/Clinical & Laboratory Immunology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Immunology",
                    Code = "2080I0007X",
                    Description = "Physicians/Allopathic/Osteopathic/Pediatrics/Clinical & Laboratory Immunology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Immunology",
                    Code = "2080P0201X",
                    Description = "Physicians/Allopathic/Osteopathic/Pediatrics/Pediatric Allergy & Immunology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Infectious Disease",
                    Code = "207RI0200X",
                    Description = "Physicians/Allopathic/Osteopathic/Internal Medicine/Infectious Disease"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Infectious Disease",
                    Code = "2080P0208X",
                    Description = "Physicians/Allopathic/Osteopathic/Pediatrics/Pediatric Infectious Diseases"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Internal Medicine",
                    Code = "111NI0900X",
                    Description = "Chiropractors/Chiropractor/Internist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Internal Medicine",
                    Code = "207R00000X",
                    Description = "Physicians/Allopathic/Osteopathic/Internal Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Internal Medicine",
                    Code = "207R10008X",
                    Description = "Physicians/Allopathic/Osteopathic/Internal Medicine/Hepatology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Internal Medicine",
                    Code = "207RA0401X",
                    Description = "Physicians/Allopathic/Osteopathic/Internal Medicine/Addiction Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Internal Medicine",
                    Code = "207RS0010X",
                    Description = "Physicians/Allopathic/Osteopathic/Internal Medicine/Sports Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Internal Medicine",
                    Code = "208M00000X",
                    Description = "Physicians/Allopathic/Osteopathic/Hospitalist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Internal Medicine",
                    Code = "363LA2200X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner/Adult Health"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Internal Medicine",
                    Code = "364SA2200X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist/Adult Health"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Internal Medicine",
                    Code = "364SC2300X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist/Chronic Care"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "170100000X",
                    Description = "Other Service Providers/Medical Genetics: Ph.D. Medical Genetics"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "174M00000X",
                    Description = "Other Service Providers/Veterinarian"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "174MM1900X",
                    Description = "Other Service Providers/Veterinarian/Medical Research"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "207ZB0001X",
                    Description = "Physicians/Allopathic/Osteopathic/Pathology/Blood Banking & Transfusion Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "207ZC0500X",
                    Description = "Physicians/Allopathic/Osteopathic/Pathology/Pathology & Cytopathology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "207ZD0900X",
                    Description = "Physicians/Allopathic/Osteopathic/Pathology/Dermatopathology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "207ZF0201X",
                    Description = "Physicians/Allopathic/Osteopathic/Pathology/Forensic Pathology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "207ZH0000X",
                    Description = "Physicians/Allopathic/Osteopathic/Pathology/Hematology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "207ZI0100X",
                    Description = "Physicians/Allopathic/Osteopathic/Pathology/Immunopathology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "207ZM0300X",
                    Description = "Physicians/Allopathic/Osteopathic/Pathology/Medical Microbiology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "207ZN0500X",
                    Description = "Physicians/Allopathic/Osteopathic/Pathology/Neuropathology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "207ZP0007X",
                    Description = "Physicians/Allopathic/Osteopathic/Pathology/Molecular Genetic Pathology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "207ZP0101X",
                    Description = "Physicians/Allopathic/Osteopathic/Pathology/Anatomic Pathology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "207ZP0102X",
                    Description = "Physicians/Allopathic/Osteopathic/Pathology/Anatomic Pathology & Clinical Pathology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "207ZP0104X",
                    Description = "Physicians/Allopathic/Osteopathic/Pathology/Chemical Pathology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "207ZP0213X",
                    Description = "Physicians/Allopathic/Osteopathic/Pathology/Pediatric Pathology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "2080T0002X",
                    Description = "Physicians/Allopathic/Osteopathic/Pediatrics/Medical Toxicology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "2083T0002X",
                    Description =
                        "Physicians/Allopathic/Osteopathic/Preventive & Occupational Medicine/Preventive Medicine/Medical Toxicology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "246Q00000X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Specialist/Technologist/Pathology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "246QB0000X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Specialist/Technologist/Pathology/Pathology/Blood Banking"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "246QC1000X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Specialist/Technologist/Pathology/Chemistry"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "246QC2700X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Specialist/Technologist/Pathology/Cytotechnology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "246QH0000X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Specialist/Technologist/Pathology/Hematology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "246QH0401X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Specialist/Technologist/Pathology/Hemapheresis Practitioner"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "246QH0600X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Specialist/Technologist/Pathology/Histology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "246QI0000X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Specialist/Technologist/Pathology/Immunology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "246QL0900X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Specialist/Technologist/Pathology/Laboratory Management"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "246QL0901X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Specialist/Technologist/Pathology/Laboratory Management, Diplomate"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "246QM0706X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Specialist/Technologist/Pathology/Medical Technologist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "246QM0900X",
                    Description = "Technologists, Technicians & Other Technical Service Providers/Technician/Pathology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "246R00000X",
                    Description = "Technologists, Technicians & Other Technical Service Providers/Technician/Pathology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "246RH0600X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Technician/Pathology/Histology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "246RM2200X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Technician/Pathology/Medical Laboratory"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "246RP1900X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Technician/Pathology/Phlebotomy"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Laboratory/Pathology",
                    Code = "246ZB0500X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Specialist/Technologist/Other/Biochemist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Medical Genetics",
                    Code = "207RX0202X",
                    Description = "Physicians/Allopathic/Osteopathic/Medical Genetics"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Medical Genetics",
                    Code = "207SC0300X",
                    Description = "Physicians/Allopathic/Osteopathic/Medical Genetics/Clinical Cytogenetics"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Medical Genetics",
                    Code = "207SG0201X",
                    Description = "Physicians/Allopathic/Osteopathic/Medical Genetics/Clinical Genetics (M.D.)"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Medical Genetics",
                    Code = "207SG0202X",
                    Description = "Physicians/Allopathic/Osteopathic/Medical Genetics/Clinical Biochemical Genetics"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Medical Genetics",
                    Code = "207SG0203X",
                    Description = "Physicians/Allopathic/Osteopathic/Medical Genetics/Clinical Molecular Genetics"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Medical Genetics",
                    Code = "207SG0205X",
                    Description = "Physicians/Allopathic/Osteopathic/Medical Genetics/Ph.D. Medical Genetics"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Medical Genetics",
                    Code = "207SM0001X",
                    Description = "Physicians/Allopathic/Osteopathic/Medical Genetics/Molecular Genetic Pathology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Medical Genetics",
                    Code = "246ZG1000X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Specialist/Technologist/Other/Geneticist/Medical (PhD)"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Metabolic Disease",
                    Code = "163WD0400X",
                    Description = "Nursing Service Providers/Registered Nurse/Diabetes Educator"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Neonatal/Perinatal medicine",
                    Code = "163WN0002X",
                    Description = "Nursing Service Providers/Registered Nurse/Neonatal Intensive Care"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Neonatal/Perinatal medicine",
                    Code = "163WN0003X",
                    Description = "Nursing Service Providers/Registered Nurse/Neonatal, Low-Risk"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Neonatal/Perinatal medicine",
                    Code = "163WP1700X",
                    Description = "Nursing Service Providers/Registered Nurse/Perinatal"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Neonatal/Perinatal medicine",
                    Code = "207VE0102X",
                    Description = "Physicians/Allopathic/Osteopathic/Obstetrics & Gynecology/Critical Care Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Neonatal/Perinatal medicine",
                    Code = "2080N0001X",
                    Description = "Physicians/Allopathic/Osteopathic/Pediatrics/Neonatal-Perinatal Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Neonatal/Perinatal medicine",
                    Code = "363LN0000X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner/Neonatal"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Neonatal/Perinatal medicine",
                    Code = "363LN0005X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner/Neonatal/Critical Care"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Neonatal/Perinatal medicine",
                    Code = "363LP1700X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner/Perinatal"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Neonatal/Perinatal medicine",
                    Code = "364SN0000X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist/Neonatal"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Neonatal/Perinatal medicine",
                    Code = "364SP1700X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist/Perinatal"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nephrology",
                    Code = "163WD1100X",
                    Description = "Nursing Service Providers/Registered Nurse/Dialysis, Peritoneal"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nephrology",
                    Code = "163WH0500X",
                    Description = "Nursing Service Providers/Registered Nurse/Hemodialysis"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nephrology",
                    Code = "163WN0300X",
                    Description = "Nursing Service Providers/Registered Nurse/Nephrology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nephrology",
                    Code = "207RN0300X",
                    Description = "Physicians/Allopathic/Osteopathic/Internal Medicine/Nephrology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nephrology",
                    Code = "2080P0210X",
                    Description = "Physicians/Allopathic/Osteopathic/Pediatrics/Pediatric Nephrology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nephrology",
                    Code = "246ZN0300X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Specialist/Technologist/Other/Nephrology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nephrology",
                    Code = "2472R0900X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Technician/Other/Renal Dialysis"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Neurology",
                    Code = "111NN0400X",
                    Description = "Chiropractors/Chiropractor/Neurology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Neurology",
                    Code = "163WN0800X",
                    Description = "Nursing Service Providers/Registered Nurse/Neuroscience"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Neurology",
                    Code = "208400400X",
                    Description = "Physicians/Allopathic/Osteopathic/Psychiatry & Neurology/Neurology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Neurology",
                    Code = "2084N0402X",
                    Description = "Physicians/Allopathic/Osteopathic/Psychiatry & Neurology/Neurology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Neurology",
                    Code = "2084N0600X",
                    Description = "Physicians/Allopathic/Osteopathic/Psychiatry & Neurology/Clinical Neurophysiology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Neurology",
                    Code = "2084N0600X",
                    Description =
                        "Physicians/Allopathic/Osteopathic/Psychiatry & Neurology/Neurology with Special Qualifications in Child Neurology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Neurology",
                    Code = "2084P0005X",
                    Description =
                        "Physicians/Allopathic/Osteopathic/Psychiatry & Neurology/Neurodevelopmental Disabilities"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Neurology",
                    Code = "2084P2900X",
                    Description = "Physicians/Allopathic/Osteopathic/Psychiatry & Neurology/Pain Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Neurology",
                    Code = "2084S0010X",
                    Description = "Physicians/Allopathic/Osteopathic/Psychiatry & Neurology/Sports Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Neurology",
                    Code = "2084V0102X",
                    Description = "Physicians/Allopathic/Osteopathic/Psychiatry & Neurology/Vascular Neurology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Neurology",
                    Code = "208VP0000X",
                    Description = "Physicians/Allopathic/Osteopathic/Pain Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Neurology",
                    Code = "208VP0014X",
                    Description = "Physicians/Allopathic/Osteopathic/Pain Medicine/Pain Management"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Neurology",
                    Code = "246ZE0600X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Specialist/Technologist/Other/Electroneurodiagnostic"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Neurology",
                    Code = "2472E0500X",
                    Description = "Technologists, Technicians & Other Technical Service Providers/Technician/Other/EEG"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Neurology",
                    Code = "364SN0800X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist/Neuroscience"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nuclear Medicine",
                    Code = "1835N0905X",
                    Description = "Pharmacy Service Providers/Pharmacist/Nuclear Pharmacy"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nuclear Medicine",
                    Code = "207U00000X",
                    Description = "Physicians/Allopathic/Osteopathic/Nuclear Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nuclear Medicine",
                    Code = "207UN0901X",
                    Description = "Physicians/Allopathic/Osteopathic/Nuclear Medicine/Nuclear Cardiology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nuclear Medicine",
                    Code = "207UN0902X",
                    Description = "Physicians/Allopathic/Osteopathic/Nuclear Medicine/Nuclear Imaging & Therapy"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nuclear Medicine",
                    Code = "207UN0903X",
                    Description =
                        "Physicians/Allopathic/Osteopathic/Nuclear Medicine/In Vivo & In Vitro Nuclear Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nuclear Medicine",
                    Code = "2471N0900X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Radiologic Technologist/Nuclear Medicine Technology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "163W00000X",
                    Description = "Nursing Service Providers/Registered Nurse"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "163WA0400X",
                    Description = "Nursing Service Providers/Registered Nurse/Addiction (Substance Use Disorder)"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "163WA2000X",
                    Description = "Nursing Service Providers/Registered Nurse/Administrator"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "163WC0400X",
                    Description = "Nursing Service Providers/Registered Nurse/Case Management"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "163WC1400X",
                    Description = "Nursing Service Providers/Registered Nurse/College Health"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "163WC1600X",
                    Description = "Nursing Service Providers/Registered Nurse/Continuing Education/Staff Development"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "163WC2100X",
                    Description = "Nursing Service Providers/Registered Nurse/Continence Care"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "163WE0900X",
                    Description = "Nursing Service Providers/Registered Nurse/Enterostomal Therapy"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "163WF0300X",
                    Description = "Nursing Service Providers/Registered Nurse/Flight"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "163WG0000X",
                    Description = "Nursing Service Providers/Registered Nurse/General Practice"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "163WH0200X",
                    Description = "Nursing Service Providers/Registered Nurse/Home Health"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "163WH1000X",
                    Description = "Nursing Service Providers/Registered Nurse/Hospice"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "163WI0500X",
                    Description = "Nursing Service Providers/Registered Nurse/Infusion Therapy"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "163WI0600X",
                    Description = "Nursing Service Providers/Registered Nurse/Infection Control"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "163WL0100X",
                    Description = "Nursing Service Providers/Registered Nurse/Lactation Consultant"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "163WM0705X",
                    Description = "Nursing Service Providers/Registered Nurse/Medical-Surgical"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "163WM1400X",
                    Description = "Nursing Service Providers/Registered Nurse/Massage Therapy"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "163WP0000X",
                    Description = "Nursing Service Providers/Registered Nurse/Pain Management"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "163WP2201X",
                    Description = "Nursing Service Providers/Registered Nurse/Ambulatory Care"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "163WS0200X",
                    Description = "Nursing Service Providers/Registered Nurse/School"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "163WW0000X",
                    Description = "Nursing Service Providers/Registered Nurse/Wound Care"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "163WW0101X",
                    Description = "Nursing Service Providers/Registered Nurse/Women's Health Care, Ambulatory"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "163WX0601X",
                    Description = "Nursing Service Providers/Registered Nurse/Otorhinolaryngology & Head-Neck"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "163WX1500X",
                    Description = "Nursing Service Providers/Registered Nurse/Ostomy Care"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "164W00000X",
                    Description = "Nursing Service Providers/Licensed Practical Nurse"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "164X00000X",
                    Description = "Nursing Service Providers/Licensed Vocational Nurse"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "363LP2300X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner/Primary Care"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "364S00000X",
                    Description = "Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "374700000X",
                    Description = "Nursing Service Related Providers/Technician"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "3747P1801X",
                    Description = "Nursing Service Related Providers/Technician/Personal Care Attendent"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "374T00000X",
                    Description = "Nursing Service Related Providers/Christian Science Practitioner/Nurse"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "374U00000X",
                    Description = "Nursing Service Related Providers/Home Health Aide"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "376G00000X",
                    Description = "Nursing Service Related Providers/Nursing Home Administrator"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "376J00000X",
                    Description = "Nursing Service Related Providers/Homemaker"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nursing",
                    Code = "376K00000X",
                    Description = "Nursing Service Related Providers/Nurse's Aide"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nutrition",
                    Code = "111NN1001X",
                    Description = "Chiropractors/Chiropractor/Nutrition"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nutrition",
                    Code = "133N00000X",
                    Description = "Dietary & Nutritional Service Providers/Nutritionist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nutrition",
                    Code = "133NN1002X",
                    Description = "Dietary & Nutritional Service Providers/Nutritionist/Nutrition, Education"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nutrition",
                    Code = "133VN1004X",
                    Description = "Dietary & Nutritional Service Providers/Dietician, Registered/Nutrition, Pediatric"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nutrition",
                    Code = "133VN1005X",
                    Description = "Dietary & Nutritional Service Providers/Dietician, Registered/Nutrition, Renal"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nutrition",
                    Code = "133VN1006X",
                    Description = "Dietary & Nutritional Service Providers/Dietician, Registered/Nutrition, Metabolic"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nutrition",
                    Code = "163WN1003X",
                    Description = "Nursing Service Providers/Registered Nurse/Nutrition Support"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nutrition",
                    Code = "1835N1003X",
                    Description = "Pharmacy Service Providers/Pharmacist/Nutrition Support"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "OB/GYN",
                    Code = "207VC0200X",
                    Description = "Physicians/Allopathic/Osteopathic/Obstetrics & Gynecology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "OB/GYN",
                    Code = "363LX0001X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner/Obstetrics & Gynecology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Obstetrics",
                    Code = "163WX0002X",
                    Description = "Nursing Service Providers/Registered Nurse/Obstetric, High-Risk"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Obstetrics",
                    Code = "163WX0003X",
                    Description = "Nursing Service Providers/Registered Nurse/Obstetric, IPracticioneratient"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Obstetrics",
                    Code = "175M00000X",
                    Description = "Other Service Providers/Midwife, Lay"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Obstetrics",
                    Code = "176B00000X",
                    Description = "Other Service Providers/Midwife, Certified"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Obstetrics",
                    Code = "207VM0101X",
                    Description = "Physicians/Allopathic/Osteopathic/Obstetrics & Gynecology/Maternal & Fetal Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Obstetrics",
                    Code = "207VX0000X",
                    Description = "Physicians/Allopathic/Osteopathic/Obstetrics & Gynecology/Obstetrics"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Obstetrics",
                    Code = "367A00000X",
                    Description = "Physician Assistants & Advanced Practice Nursing Providers/Midwife/ Certified Nurse"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Occupational Health",
                    Code = "111NX0100X",
                    Description = "Chiropractors/Chiropractor/Occupational Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Occupational Health",
                    Code = "163WX0106X",
                    Description = "Nursing Service Providers/Registered Nurse/Occupational Health"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Occupational Health",
                    Code = "2083P0500X",
                    Description =
                        "Physicians/Allopathic/Osteopathic/Preventive & Occupational Medicine/Occupational Environmental Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Occupational Health",
                    Code = "2083X0100X",
                    Description =
                        "Physicians/Allopathic/Osteopathic/Preventive & Occupational Medicine/Occupational Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Occupational Health",
                    Code = "363LX0106X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner/Occupational Health"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Occupational Health",
                    Code = "364SX0106X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist/Occupational Health"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Oncology",
                    Code = "163WP0218X",
                    Description = "Nursing Service Providers/Registered Nurse/Pediatrics, Pediatric Oncology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Oncology",
                    Code = "163WX0200X",
                    Description = "Nursing Service Providers/Registered Nurse/Oncology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Oncology",
                    Code = "207RH0003X",
                    Description = "Physicians/Allopathic/Osteopathic/Internal Medicine/Hematology & Oncology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Oncology",
                    Code = "207RX0202X",
                    Description = "Physicians/Allopathic/Osteopathic/Internal Medicine/Medical Oncology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Oncology",
                    Code = "2080P0207X",
                    Description = "Physicians/Allopathic/Osteopathic/Pediatrics/Pediatric Hematology-Oncology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Oncology",
                    Code = "364SX0200X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist/Oncology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Oncology",
                    Code = "364SX0204X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist/Oncology/Pediatrics"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Ophthalmology",
                    Code = "163WX1100X",
                    Description = "Nursing Service Providers/Registered Nurse/Ophthalmic"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Ophthalmology",
                    Code = "207W00000X",
                    Description = "Physicians/Allopathic/Osteopathic/Opthalmology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Optometry",
                    Code = "152W00000X",
                    Description = "Eye and Vision Services Providers/Optometrist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Optometry",
                    Code = "152WC0802X",
                    Description = "Eye and Vision Services Providers/Optometrist/Corneal and Contact Management"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Optometry",
                    Code = "152WL0500X",
                    Description = "Eye and Vision Services Providers/Optometrist/Low Vision Rehabilitation"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Optometry",
                    Code = "152WP0200X",
                    Description = "Eye and Vision Services Providers/Optometrist/Pediatrics"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Optometry",
                    Code = "152WS0006X",
                    Description = "Eye and Vision Services Providers/Optometrist/Sports Vision"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Optometry",
                    Code = "152WV0400X",
                    Description = "Eye and Vision Services Providers/Optometrist/Vision Therapy"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Optometry",
                    Code = "152WX0102X",
                    Description = "Eye and Vision Services Providers/Optometrist/Occupational Vision"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Optometry",
                    Code = "156F00000X",
                    Description = "Eye and Vision Services Providers/Technician/Technologist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Optometry",
                    Code = "156FC0800X",
                    Description = "Eye and Vision Services Providers/Technician/Technologist/Contact Lens"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Optometry",
                    Code = "156FC0801X",
                    Description = "Eye and Vision Services Providers/Technician/Technologist/Contact Lens Fitter"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Optometry",
                    Code = "156FX1100X",
                    Description = "Eye and Vision Services Providers/Technician/Technologist/Ophthalmic"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Optometry",
                    Code = "156FX1101X",
                    Description = "Eye and Vision Services Providers/Technician/Technologist/Ophthalmic Assistant"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Optometry",
                    Code = "156FX1201X",
                    Description = "Eye and Vision Services Providers/Technician/Technologist/Optometric Assistant"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Optometry",
                    Code = "156FX1202X",
                    Description = "Eye and Vision Services Providers/Technician/Technologist/Optometric Technician"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Optometry",
                    Code = "156FX1700X",
                    Description = "Eye and Vision Services Providers/Technician/Technologist/Ocularist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Optometry",
                    Code = "156FX1800X",
                    Description = "Eye and Vision Services Providers/Technician/Technologist/Optician"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Optometry",
                    Code = "156FX1900X",
                    Description = "Eye and Vision Services Providers/Technician/Technologist/Orthoptist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Orthopedics",
                    Code = "111NX0800X",
                    Description = "Chiropractors/Chiropractor/Uncategorized: Orthopedic"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Orthopedics",
                    Code = "163WX0800X",
                    Description = "Nursing Service Providers/Registered Nurse/Orthopedic"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Orthopedics",
                    Code = "207X00000X",
                    Description = "Physicians/Allopathic/Osteopathic/Orthopaedic Surgery"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Orthopedics",
                    Code = "207XS0106X",
                    Description = "Physicians/Allopathic/Osteopathic/Orthopaedic Surgery/Hand Surgery"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Orthopedics",
                    Code = "207XS0114X",
                    Description =
                        "Physicians/Allopathic/Osteopathic/Orthopaedic Surgery/Adult Reconstructive Orthopaedic Surgery"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Orthopedics",
                    Code = "207XS0117X",
                    Description =
                        "Physicians/Allopathic/Osteopathic/Orthopaedic Surgery/Orthopaedic Surgery of the Spine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Orthopedics",
                    Code = "207XX0004X",
                    Description = "Physicians/Allopathic/Osteopathic/Orthopaedic Surgery/Foot and Ankle Orthopaedics"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Orthopedics",
                    Code = "207XX0005X",
                    Description = "Physicians/Allopathic/Osteopathic/Orthopaedic Surgery/Sports Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Orthopedics",
                    Code = "207XX0801X",
                    Description = "Physicians/Allopathic/Osteopathic/Orthopaedic Surgery/Orthopaedic Trauma"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Orthopedics",
                    Code = "2080S0010X",
                    Description = "Physicians/Allopathic/Osteopathic/Pediatrics/Sports Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Otorhinolaryngology",
                    Code = "204E00000X",
                    Description = "Physicians/Allopathic/Osteopathic/Oral & Maxillofacial Surgery"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Otorhinolaryngology",
                    Code = "207Y00000X",
                    Description = "Physicians/Allopathic/Osteopathic/Otolaryngology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Otorhinolaryngology",
                    Code = "207YP0228X",
                    Description = "Physicians/Allopathic/Osteopathic/Otolaryngology/Pediatric Otolaryngology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Otorhinolaryngology",
                    Code = "207YX0602X",
                    Description = "Physicians/Allopathic/Osteopathic/Otolaryngology/Otolaryngic Allergy"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Otorhinolaryngology",
                    Code = "207YX0901X",
                    Description = "Physicians/Allopathic/Osteopathic/Otolaryngology/Otology & Neurotology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Otorhinolaryngology",
                    Code = "207YX0905X",
                    Description =
                        "Physicians/Allopathic/Osteopathic/Otolaryngology/Otolaryngology/Facial Plastic Surgery"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Pediatrics",
                    Code = "163WM0102X",
                    Description = "Nursing Service Providers/Registered Nurse/Maternal Newborn"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Pediatrics",
                    Code = "163WP0200X",
                    Description = "Nursing Service Providers/Registered Nurse/Pediatrics"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Pediatrics",
                    Code = "207ZP0105X",
                    Description = "Physicians/Allopathic/Osteopathic/Pathology/Clinical Pathology/Laboratory Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Pediatrics",
                    Code = "208000000X",
                    Description = "Physicians/Allopathic/Osteopathic/Pediatrics"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Pediatrics",
                    Code = "2080P0006X",
                    Description = "Physicians/Allopathic/Osteopathic/Pediatrics/Developmental-Behavioral Pediatrics"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Pediatrics",
                    Code = "2080P0202X",
                    Description = "Physicians/Allopathic/Osteopathic/Pediatrics/Pediatric Cardiology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Pediatrics",
                    Code = "2080P0203X",
                    Description = "Physicians/Allopathic/Osteopathic/Pediatrics/Pediatric Critical Care Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Pediatrics",
                    Code = "2080P0204X",
                    Description = "Physicians/Allopathic/Osteopathic/Pediatrics/Pediatric Emergency Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Pediatrics",
                    Code = "363LP0200X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner/Pediatrics"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Pediatrics",
                    Code = "364SP0200X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist/Pediatrics"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Pediatrics, Developmental",
                    Code = "2080P0008X",
                    Description = "Physicians/Allopathic/Osteopathic/Pediatrics/Neurodevelopmental Disabilities"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Peripheral Vascular Medicine",
                    Code = "246XC2903X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Specialist/Technologist Cardiovascular/Vascular Specialist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Physical Medicine & Rehabilitation",
                    Code = "111NS0005X",
                    Description = "Chiropractors/Chiropractor/Sports Physician"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Physical Medicine & Rehabilitation",
                    Code = "163WC3500X",
                    Description = "Nursing Service Providers/Registered Nurse/Cardiac Rehabilitation"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Physical Medicine & Rehabilitation",
                    Code = "163WR0400X",
                    Description = "Nursing Service Providers/Registered Nurse/Rehabilitation"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Physical Medicine & Rehabilitation",
                    Code = "1744P3200X",
                    Description = "Other Service Providers/Specialist/Prosthetics Case Management"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Physical Medicine & Rehabilitation",
                    Code = "204C00000X",
                    Description = "Physicians/Allopathic/Osteopathic/Neuromusculoskeletal Medicine/Sports Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Physical Medicine & Rehabilitation",
                    Code = "204D00000X",
                    Description = "Physicians/Allopathic/Osteopathic/Neuromusculoskeletal Medicine & OMM"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Physical Medicine & Rehabilitation",
                    Code = "208100000X",
                    Description = "Physicians/Allopathic/Osteopathic/Physical Medicine & Rehabilitation"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Physical Medicine & Rehabilitation",
                    Code = "2081P0004X",
                    Description =
                        "Physicians/Allopathic/Osteopathic/Physical Medicine & Rehabilitation/Spinal Cord Injury Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Physical Medicine & Rehabilitation",
                    Code = "2081P0010X",
                    Description =
                        "Physicians/Allopathic/Osteopathic/Physical Medicine & Rehabilitation/Pediatric Rehabilitation Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Physical Medicine & Rehabilitation",
                    Code = "2081P2900X",
                    Description = "Physicians/Allopathic/Osteopathic/Physical Medicine & Rehabilitation/Pain Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Physical Medicine & Rehabilitation",
                    Code = "2081S0010X",
                    Description = "Physicians/Allopathic/Osteopathic/Physical Medicine & Rehabilitation/Sports Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Physical Medicine & Rehabilitation",
                    Code = "364SR0400X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist/Rehabilitation"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Podiatry",
                    Code = "211D00000X",
                    Description = "Podiatric Medicine & Surgery Service Providers/Assistant, Podiatric"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Podiatry",
                    Code = "213E00000X",
                    Description = "Podiatric Medicine & Surgery Service Providers/Podiatrist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Podiatry",
                    Code = "213EG0000X",
                    Description = "Podiatric Medicine & Surgery Service Providers/Podiatrist/General Practice"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Podiatry",
                    Code = "213EP0504X",
                    Description =
                        "Podiatric Medicine & Surgery Service Providers/Podiatrist/Preventive Medicine/Public Health"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Podiatry",
                    Code = "213EP1101X",
                    Description =
                        "Podiatric Medicine & Surgery Service Providers/Podiatrist/Primary Podiatric Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Podiatry",
                    Code = "213ER0200X",
                    Description = "Podiatric Medicine & Surgery Service Providers/Podiatrist/Radiology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Podiatry",
                    Code = "213ES0000X",
                    Description = "Podiatric Medicine & Surgery Service Providers/Podiatrist/Sports Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Podiatry",
                    Code = "213ES0103X",
                    Description = "Podiatric Medicine & Surgery Service Providers/Podiatrist/Surgery/ Foot & Ankle"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Podiatry",
                    Code = "213ES0131X",
                    Description = "Podiatric Medicine & Surgery Service Providers/Podiatrist/Surgery/Foot"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Preventive Medicine",
                    Code = "2083P0901X",
                    Description =
                        "Physicians/Allopathic/Osteopathic/Preventive & Occupational Medicine/Public Health & General Preventive Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Preventive Medicine",
                    Code = "2083S0010X",
                    Description =
                        "Physicians/Allopathic/Osteopathic/Preventive & Occupational Medicine/Preventive Medicine/Sports Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Proctology",
                    Code = "208C00000X",
                    Description = "Physicians/Allopathic/Osteopathic/Colon & Rectal Surgery"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychiatry",
                    Code = "163WP0807X",
                    Description =
                        "Nursing Service Providers/Registered Nurse/Psychiatric/Mental Health, Child & Adolescent"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychiatry",
                    Code = "163WP0808X",
                    Description = "Nursing Service Providers/Registered Nurse/ Psychiatric/Mental Health"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychiatry",
                    Code = "163WP0809X",
                    Description = "Nursing Service Providers/Registered Nurse/Psychiatric/Mental Health, Adult"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychiatry",
                    Code = "167G00000X",
                    Description = "Licensed Psychiatric Technician"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychiatry",
                    Code = "2084A0401X",
                    Description = "Physicians/Allopathic/Osteopathic/Psychiatry & Neurology/Addiction Medicine"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychiatry",
                    Code = "2084F0202X",
                    Description = "Physicians/Allopathic/Osteopathic/Psychiatry & Neurology/Forensic Psychiatry"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychiatry",
                    Code = "2084P0800X",
                    Description = "Physicians/Allopathic/Osteopathic/Psychiatry & Neurology/Psychiatry"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychiatry",
                    Code = "2084P0802X",
                    Description = "Physicians/Allopathic/Osteopathic/Psychiatry & Neurology/Addiction Psychiatry"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychiatry",
                    Code = "2084P0804X",
                    Description =
                        "Physicians/Allopathic/Osteopathic/Psychiatry & Neurology/Child & Adolescent Psychiatry"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychiatry",
                    Code = "2084P0805X",
                    Description = "Physicians/Allopathic/Osteopathic/Psychiatry & Neurology/Geriatric Psychiatry"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychiatry",
                    Code = "363LP0808X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Nurse Practitioner/Psychiatric/Mental Health"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychiatry",
                    Code = "364SP0807X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist/Psychiatric/Mental Health/Child & Adolescent"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychiatry",
                    Code = "364SP0808X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist/Psychiatric/Mental Health"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychiatry",
                    Code = "364SP0809X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist/Psychiatric/Mental Health/Adult"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychiatry",
                    Code = "364SP0810X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist/Psychiatric/Mental Health/Child & Family"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychiatry",
                    Code = "364SP0811X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist/Psychiatric/Mental Health/Chronically Ill"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychiatry",
                    Code = "364SP0812X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist/Psychiatric/Mental Health/Community"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychiatry",
                    Code = "364SP0813X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist/Psychiatric/Mental Health/Geropsychiatric"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychology",
                    Code = "101Y00000X",
                    Description = "Behavioral Health & Social Service Providers/Counselor"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychology",
                    Code = "101YA0400X",
                    Description =
                        "Behavioral Health & Social Service Providers/Counselor/Addiction (Substance Use Disorder)"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychology",
                    Code = "101YM0800X",
                    Description = "Behavioral Health & Social Service Providers/Counselor/Mental Health"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychology",
                    Code = "101YP1600X",
                    Description = "Behavioral Health & Social Service Providers/Counselor/Pastoral"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychology",
                    Code = "101YP2500X",
                    Description = "Behavioral Health & Social Service Providers/Counselor/Professional"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychology",
                    Code = "101YS0200X",
                    Description = "Behavioral Health & Social Service Providers/Counselor/School"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychology",
                    Code = "103G00000X",
                    Description = "Behavioral Health & Social Service Providers/Neuropsychologist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychology",
                    Code = "103GC0700X",
                    Description = "Behavioral Health & Social Service Providers/Neuropsychologist/Clinical"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychology",
                    Code = "103T00000X",
                    Description = "Behavioral Health & Social Service Providers/Psychologist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychology",
                    Code = "103TA0400X",
                    Description =
                        "Behavioral Health & Social Service Providers/Psychologist/Addiction (Substance Use Disorder)"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychology",
                    Code = "103TA0700X",
                    Description = "Behavioral Health & Social Service Providers/Psychologist/Adult Development & Aging"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychology",
                    Code = "103TB0200X",
                    Description = "Behavioral Health & Social Service Providers/Psychologist/Behavioral"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychology",
                    Code = "103TC0700X",
                    Description = "Behavioral Health & Social Service Providers/Psychologist/Clinical"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychology",
                    Code = "103TC1900X",
                    Description = "Behavioral Health & Social Service Providers/Psychologist/Counseling"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychology",
                    Code = "103TC2200X",
                    Description = "Behavioral Health & Social Service Providers/Psychologist/Child, Youth & Family"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychology",
                    Code = "103TE1000X",
                    Description = "Behavioral Health & Social Service Providers/Psychologist/Educational"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychology",
                    Code = "103TE1100X",
                    Description = "Behavioral Health & Social Service Providers/Psychologist/Exercise & Sports"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychology",
                    Code = "103TF0000X",
                    Description = "Behavioral Health & Social Service Providers/Psychologist/Family"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychology",
                    Code = "103TF0200X",
                    Description = "Behavioral Health & Social Service Providers/Psychologist/Forensic"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychology",
                    Code = "103TH0100X",
                    Description = "Behavioral Health & Social Service Providers/Psychologist/Health"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychology",
                    Code = "103TM1700X",
                    Description = "Behavioral Health & Social Service Providers/Psychologist/Men & Masculinity"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychology",
                    Code = "103TM1800X",
                    Description =
                        "Behavioral Health & Social Service Providers/Psychologist/Mental Retardation & Developmental Disabilities"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychology",
                    Code = "103TP0814X",
                    Description = "Behavioral Health & Social Service Providers/Psychologist/Psychoanalysis"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychology",
                    Code = "103TP2700X",
                    Description = "Behavioral Health & Social Service Providers/Psychologist/Psychotherapy"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychology",
                    Code = "103TP2701X",
                    Description = "Behavioral Health & Social Service Providers/Psychologist/Psychotherapy, Group"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychology",
                    Code = "103TR0400X",
                    Description = "Behavioral Health & Social Service Providers/Psychologist/Rehabilitation"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychology",
                    Code = "103TS0200X",
                    Description = "Behavioral Health & Social Service Providers/Psychologist/School"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychology",
                    Code = "103TW0100X",
                    Description = "Behavioral Health & Social Service Providers/Psychologist/Women"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Psychology",
                    Code = "106H00000X",
                    Description = "Behavioral Health & Social Service Providers/Marriage & Family Therapist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Pulmonary Disease",
                    Code = "207RP1001X",
                    Description = "Physicians/Allopathic/Osteopathic/Internal Medicine/Pulmonary Disease"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Pulmonary Disease",
                    Code = "2080P0214X",
                    Description = "Physicians/Allopathic/Osteopathic/Pediatrics/Pediatric Pulmonology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Radiology",
                    Code = "111NR0200X",
                    Description = "Chiropractors/Chiropractor/Radiology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Radiology",
                    Code = "207RM1200X",
                    Description = "Physicians/Allopathic/Osteopathic/Internal Medicine/Magnetic Resonance Imaging (MRI)"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Radiology",
                    Code = "2085B0100X",
                    Description = "Physicians/Allopathic/Osteopathic/Radiology/Body Imaging"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Radiology",
                    Code = "2085N0700X",
                    Description = "Physicians/Allopathic/Osteopathic/Radiology/Neuroradiology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Radiology",
                    Code = "2085N0904X",
                    Description = "Physicians/Allopathic/Osteopathic/Radiology/Nuclear Radiology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Radiology",
                    Code = "2085P0229X",
                    Description = "Physicians/Allopathic/Osteopathic/Radiology/Pediatrics/Pediatric Radiology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Radiology",
                    Code = "2085R0202X",
                    Description = "Physicians/Allopathic/Osteopathic/Radiology/Diagnostic Radiology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Radiology",
                    Code = "2085R0204X",
                    Description = "Physicians/Allopathic/Osteopathic/Radiology/Vascular & Interventional Radiology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Radiology",
                    Code = "2085R0205X",
                    Description = "Physicians/Allopathic/Osteopathic/Radiology/Radiological Physics"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Radiology",
                    Code = "2085U0001X",
                    Description = "Physicians/Allopathic/Osteopathic/Radiology/Diagnostic Ultrasound"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Radiology",
                    Code = "246Y00000X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Specialist/Technologist/Health Information"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Radiology",
                    Code = "2471B0102X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Radiologic Technologist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Radiology",
                    Code = "2471C1101X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Radiologic Technologist/Bone Densitometry"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Radiology",
                    Code = "2471C1106X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Radiologic Technologist/Cardiovascular-Interventional Technology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Radiology",
                    Code = "2471C3401X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Radiologic Technologist/Computed Tomography"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Radiology",
                    Code = "2471C3402X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Radiologic Technologist/Radiography"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Radiology",
                    Code = "2471M1202X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Radiologic Technologist/Magnetic Resonance Imaging"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Radiology",
                    Code = "2471M2300X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Radiologic Technologist/Mammography"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Radiology",
                    Code = "2471S1302X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Radiologic Technologist/Sonography"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Radiology",
                    Code = "2471V0105X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Radiologic Technologist/Vascular Sonography"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Radiology",
                    Code = "2471V0106X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Radiologic Technologist/Vascular-Interventional Technology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Rheumatology",
                    Code = "207RR0500X",
                    Description = "Physicians/Allopathic/Osteopathic/Internal Medicinel/Rheumatology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Rheumatology",
                    Code = "2080P0216X",
                    Description = "Physicians/Allopathic/Osteopathic/Pediatrics/Pediatric Rheumatology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Social Worker",
                    Code = "104100000X",
                    Description = "Behavioral Health & Social Service Providers/Social Worker"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Social Worker",
                    Code = "1041C0700X",
                    Description = "Behavioral Health & Social Service Providers/Social Worker/Clinical"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Social Worker",
                    Code = "1041S0200X",
                    Description = "Behavioral Health & Social Service Providers/Social Worker/School"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Surgery",
                    Code = "163WS0121X",
                    Description = "Nursing Service Providers/Registered Nurse/Plastic Surgery"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Surgery",
                    Code = "204F00000X",
                    Description = "Physicians/Allopathic/Osteopathic/Surgery/Transplant Surgery"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Surgery",
                    Code = "207T00000X",
                    Description = "Physicians/Allopathic/Osteopathic/Neurological Surgery"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Surgery",
                    Code = "207YS0123X",
                    Description = "Physicians/Allopathic/Osteopathic/Otolaryngology/Facial Plastic Surgery"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Surgery",
                    Code = "207YX0007X",
                    Description =
                        "Physicians/Allopathic/Osteopathic/Otolaryngology/Plastic Surgery within the Head & Neck"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Surgery",
                    Code = "208200000X",
                    Description = "Physicians/Allopathic/Osteopathic/Plastic Surgery"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Surgery",
                    Code = "2082S0099X",
                    Description =
                        "Physicians/Allopathic/Osteopathic/Plastic Surgery/Plastic Surgery within the Head and Neck"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Surgery",
                    Code = "2082S0105X",
                    Description = "Physicians/Allopathic/Osteopathic/Plastic Surgery/Surgery of the Hand"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Surgery",
                    Code = "208600000X",
                    Description = "Physicians/Allopathic/Osteopathic/Surgery"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Surgery",
                    Code = "2086S0105X",
                    Description = "Physicians/Allopathic/Osteopathic/Surgery/Surgery of the Hand"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Surgery",
                    Code = "2086S0120X",
                    Description = "Physicians/Allopathic/Osteopathic/Surgery/Pediatric Surgery"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Surgery",
                    Code = "2086S0122X",
                    Description = "Physicians/Allopathic/Osteopathic/Surgery/Plastic & Reconstructive Surgery"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Surgery",
                    Code = "2086S0127X",
                    Description = "Physicians/Allopathic/Osteopathic/Surgery/Trauma Surgery"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Surgery",
                    Code = "2086S0129X",
                    Description = "Physicians/Allopathic/Osteopathic/Surgery/Vascular Surgery"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Surgery",
                    Code = "2086X0206X",
                    Description = "Physicians/Allopathic/Osteopathic/Surgery/Surgical Oncology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Surgery",
                    Code = "246ZS0400X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Specialist/Technologist/Other/Surgical"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Surgery",
                    Code = "363AS0400X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Physician Assistant/Surgical"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Surgery",
                    Code = "364SM0705X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist/Medical-Surgical"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Surgery",
                    Code = "364SP2800X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist/Perioperative"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Surgery",
                    Code = "364ST0500X",
                    Description =
                        "Physician Assistants & Advanced Practice Nursing Providers/Clinical Nurse Specialist/Transplantation"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Occupational",
                    Code = "171WH0202X",
                    Description = "Other Service Providers/Contractor/ Home Modifications"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Occupational",
                    Code = "171WV0202X",
                    Description = "Other Service Providers/Contractor/Vehicle Modifications"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Occupational",
                    Code = "225X00000X",
                    Description = "Respiratory, Rehabilitative & Restorative Service Providers/Occupational Therapist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Occupational",
                    Code = "225XE1200X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Occupational Therapist/ Ergonomics"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Occupational",
                    Code = "225XH1200X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Occupational Therapist/ Hand"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Occupational",
                    Code = "225XH1300X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Occupational Therapist/ Human Factors"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Occupational",
                    Code = "225XN1300X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Occupational Therapist/Neurorehabilitation"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Occupational",
                    Code = "225XP0200X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Occupational Therapist/Pediatrics"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Occupational",
                    Code = "225XR0403X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Occupational Therapist/ Rehabilitation, Driver"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Occupational",
                    Code = "373H00000X",
                    Description = "Nursing Service Related Providers/Day Training/Habilitation Specialist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Physical",
                    Code = "221700000X",
                    Description = "Respiratory, Rehabilitative & Restorative Service Providers/Art Therapist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Physical",
                    Code = "222Z00000X",
                    Description = "Respiratory, Rehabilitative & Restorative Service Providers/Orthotist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Physical",
                    Code = "224P00000X",
                    Description = "Respiratory, Rehabilitative & Restorative Service Providers/Prosthetist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Physical",
                    Code = "224Z00000X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Occupational Therapy Assistant"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Physical",
                    Code = "225000000X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Orthotics/Prosthetics Fitter"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Physical",
                    Code = "225100000X",
                    Description = "Respiratory, Rehabilitative & Restorative Service Providers/Physical Therapist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Physical",
                    Code = "2251C2600X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Physical Therapist/Cardiopulmonary"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Physical",
                    Code = "2251E1200X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Physical Therapist/Ergonomics"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Physical",
                    Code = "2251E1300X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Physical Therapist/Electrophysiology, Clinical"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Physical",
                    Code = "2251G0304X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Physical Therapist/Geriatrics"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Physical",
                    Code = "2251H1200X",
                    Description = "Respiratory, Rehabilitative & Restorative Service Providers/Physical Therapist/Hand"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Physical",
                    Code = "2251H1300X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Physical Therapist/Human Factors"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Physical",
                    Code = "2251N0400X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Physical Therapist/Neurology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Physical",
                    Code = "2251P0200X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Physical Therapist/Pediatrics"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Physical",
                    Code = "2251S0007X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Physical Therapist/Sports"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Physical",
                    Code = "2251X0800X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Physical Therapist/Orthopedic"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Physical",
                    Code = "225200000X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Physical Therapy Assistant"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Physical",
                    Code = "225400000X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Rehabilitation Practitioner"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Physical",
                    Code = "225500000X",
                    Description = "Respiratory, Rehabilitative & Restorative Service Providers/Specialist/Technologist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Physical",
                    Code = "2255A2300X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Specialist/Technologist/Athletic Trainer"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Physical",
                    Code = "2255R0406X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Specialist/Technologist/Rehabilitation, Blind"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Physical",
                    Code = "225600000X",
                    Description = "Respiratory, Rehabilitative & Restorative Service Providers/Dance Therapist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Physical",
                    Code = "225700000X",
                    Description = "Respiratory, Rehabilitative & Restorative Service Providers/Massage Therapist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Physical",
                    Code = "225800000X",
                    Description = "Respiratory, Rehabilitative & Restorative Service Providers/Recreation Therapist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Physical",
                    Code = "225A00000X",
                    Description = "Respiratory, Rehabilitative & Restorative Service Providers/Music Therapist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Physical",
                    Code = "225B00000X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Pulmonary Function Technologist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Physical",
                    Code = "225C00000X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Rehabilitation Counselor"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Physical",
                    Code = "225CA2400X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Rehabilitation Counselor/Assistive Technology Practitioner"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Physical",
                    Code = "225CA2500X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Rehabilitation Counselor/Assistive Technology Supplier"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Physical",
                    Code = "226300000X",
                    Description = "Respiratory, Rehabilitative & Restorative Service Providers/Kinesiotherapist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Radiation",
                    Code = "2471R0002X",
                    Description =
                        "Technologists, Technicians & Other Technical Service Providers/Radiologic Technologist/Radiation Therapy"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Respiratory",
                    Code = "227800000X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Respiratory Therapist/Certified"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Respiratory",
                    Code = "2278C0205X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Respiratory Therapist/Certified/Critical Care"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Respiratory",
                    Code = "2278E0002X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Respiratory Therapist/Certified/Emergency Care"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Respiratory",
                    Code = "2278E1000X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Respiratory Therapist/Certified/Patient Education"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Respiratory",
                    Code = "2278G0305X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Respiratory Therapist/Certified/Geriatric Care"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Respiratory",
                    Code = "2278G1100X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Respiratory Therapist/Certified/General Care"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Respiratory",
                    Code = "2278H0200X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Respiratory Therapist/Certified/Home Care"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Respiratory",
                    Code = "2278P1004X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Respiratory Therapist/Certified/Pulmonary Diagnostics"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Respiratory",
                    Code = "2278P1005X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Respiratory Therapist/Certified/Pulmonary Rehabilitation"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Respiratory",
                    Code = "2278P1006X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Respiratory Therapist/Certified/Pulmonary Function Technologist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Respiratory",
                    Code = "2278P3800X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Respiratory Therapist/Certified/Palliative/Hospice"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Respiratory",
                    Code = "2278P3900X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Respiratory Therapist/Certified/Neonatal/Pediatrics"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Respiratory",
                    Code = "2278P4000X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Respiratory Therapist/Certified/Patient Transport"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Respiratory",
                    Code = "2278S1500X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Respiratory Therapist/Certified/SNF/Subacute Care"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Respiratory",
                    Code = "227900000X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Respiratory Therapist/Registered"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Respiratory",
                    Code = "2279C0205X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Respiratory Therapist/Registered/Critical Care"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Respiratory",
                    Code = "2279E0002X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Respiratory Therapist/Registered/Emergency Care"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Respiratory",
                    Code = "2279E1000X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Respiratory Therapist/Registered/Patient Education"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Respiratory",
                    Code = "2279G0305X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Respiratory Therapist/Registered/Geriatric Care"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Respiratory",
                    Code = "2279G1100X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Respiratory Therapist/Registered/General Care"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Respiratory",
                    Code = "2279H0200X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Respiratory Therapist/Registered/Home Care"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Respiratory",
                    Code = "2279P1004X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Respiratory Therapist/Registered/Pulmonary Diagnostics"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Respiratory",
                    Code = "2279P1005X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Respiratory Therapist/Registered/Pulmonary Rehabilitation"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Respiratory",
                    Code = "2279P1006X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Respiratory Therapist/Registered/Pulmonary Function Techonologist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Respiratory",
                    Code = "2279P3800X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Respiratory Therapist/Registered/Palliative/Hospice"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Respiratory",
                    Code = "2279P3900X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Respiratory Therapist/Registered/Neonatal/Pediatrics"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Respiratory",
                    Code = "2279P4000X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Respiratory Therapist/Registered/Patient Transport"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Respiratory",
                    Code = "2279S1500X",
                    Description =
                        "Respiratory, Rehabilitative & Restorative Service Providers/Respiratory Therapist/Registered/SNF/Subacute Care"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Speech/Language Pathology",
                    Code = "2355A2700X",
                    Description =
                        "Speech, Language and Hearing Service Providers/Specialist/Technologist/Audiology Assistant"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Speech/Language Pathology",
                    Code = "2355S0801X",
                    Description =
                        "Speech, Language and Hearing Service Providers/Specialist/Technologist/Speech-Language Assistant"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Speech/Language Pathology",
                    Code = "235Z00000X",
                    Description = "Speech, Language and Hearing Service Providers/Speech-Language Pathologist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Speech/Language Pathology",
                    Code = "237600000X",
                    Description = "Speech, Language and Hearing Service Providers/Audiologist-Hearing Aid Fitter"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy, Speech/Language Pathology",
                    Code = "237700000X",
                    Description = "Speech, Language and Hearing Service Providers/Hearing Instrument Specialist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy,Radiation",
                    Code = "2085R0001X",
                    Description = "Physicians/Allopathic/Osteopathic/Radiology/Radiation Oncology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therapy,Radiation",
                    Code = "2085R0203X",
                    Description = "Physicians/Allopathic/Osteopathic/Radiology/Therapeutic Radiology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Therpay, Speech/Language Pathology",
                    Code = "235500000X",
                    Description = "Speech, Language and Hearing Service Providers/Specialist/Technologist"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Thoracic Surgery",
                    Code = "208G00000X",
                    Description = "Physicians/Allopathic/Osteopathic/Thoracic Surgery"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Urology",
                    Code = "163WU0100X",
                    Description = "Nursing Service Providers/Registered Nurse/Urology"
                },
                new Speciality()
                {
                    Id = Guid.NewGuid(),
                    Name = "Urology",
                    Code = "208800000X",
                    Description = "Physicians/Allopathic/Osteopathic/Urology"
                }
            });
        }

        private void InitPermissionModules(HippoBillingContext context)
        {
            var typeFinder = ServiceLocator.Current.GetInstance<ITypeFinder>();
            var types = typeFinder.FindClassesOfType<IPermissionModule>();
            foreach (var item in types)
            {
                var module = (IPermissionModule)ServiceLocator.Current.GetInstance(item);
                context.PermissionModules.AddOrUpdate(x => x.FullName, new PermissionModule()
                {
                    FullName = item.FullName,
                    Name = module.ModuleName,
                    Level = 1,
                    Order = module.Order,
                    Parent = null
                });
            }
        }

        private void InitServicePlaces(HippoBillingContext context)
        {
            context.ServicePlaces.AddOrUpdate(x => x.Code, new ServicePlace[]
            {
                new ServicePlace {Code = "01", Name = "Pharmacy"},
                new ServicePlace {Code = "03", Name = "School"},
                new ServicePlace {Code = "04", Name = "Homeless Shelter"},
                new ServicePlace {Code = "05", Name = "Indian Health Service Free-standing Facility"},
                new ServicePlace {Code = "06", Name = "Indian Health Service Provider-based Facility"},
                new ServicePlace {Code = "07", Name = "Tribal 638 Free-standing Facility"},
                new ServicePlace {Code = "08", Name = "Tribal 638 Provider-based Facility"},
                new ServicePlace {Code = "09", Name = "Prison/ Correctional Facility"},
                new ServicePlace {Code = "11", Name = "Office"},
                new ServicePlace {Code = "12", Name = "Home"},
                new ServicePlace {Code = "13", Name = "Assisted Living Facility"},
                new ServicePlace {Code = "14", Name = "Group Home"},
                new ServicePlace {Code = "15", Name = "Mobile Unit"},
                new ServicePlace {Code = "16", Name = "Temporary Lodging"},
                new ServicePlace {Code = "17", Name = "Walk-in Retail Health Clinic"},
                new ServicePlace {Code = "18", Name = "Place of Employment/Worksite"},
                new ServicePlace {Code = "20", Name = "Urgent Care Facility"},
                new ServicePlace {Code = "21", Name = "Inpatient Hospital"},
                new ServicePlace {Code = "22", Name = "Outpatient Hospital"},
                new ServicePlace {Code = "23", Name = "Emergency Room - Hospital"},
                new ServicePlace {Code = "24", Name = "Ambulatory Surgical Center"},
                new ServicePlace {Code = "25", Name = "Birthing Center"},
                new ServicePlace {Code = "26", Name = "Military Treatment Facility"},
                new ServicePlace {Code = "31", Name = "Skilled Nursing Facility"},
                new ServicePlace {Code = "32", Name = "Nursing Facility"},
                new ServicePlace {Code = "33", Name = "Custodial Care Facility"},
                new ServicePlace {Code = "34", Name = "Hospice"},
                new ServicePlace {Code = "41", Name = "Ambulance - Land"},
                new ServicePlace {Code = "42", Name = "Ambulance - Air or Water"},
                new ServicePlace {Code = "49", Name = "Independent Clinic"},
                new ServicePlace {Code = "50", Name = "Federally Qualified Health Center"},
                new ServicePlace {Code = "51", Name = "Inpatient Psychiatric Facility"},
                new ServicePlace {Code = "52", Name = "Psychiatric Facility-Partial Hospitalization"},
                new ServicePlace {Code = "53", Name = "Community Mental Health Center"},
                new ServicePlace {Code = "54", Name = "Intermediate Care Facility/Mentally Retarded"},
                new ServicePlace {Code = "55", Name = "Residential Substance Abuse Treatment Facility"},
                new ServicePlace {Code = "56", Name = "Psychiatric Residential Treatment Center"},
                new ServicePlace {Code = "57", Name = "Non-residential Substance Abuse Treatment Facility"},
                new ServicePlace {Code = "60", Name = "Mass Immunization Center"},
                new ServicePlace {Code = "61", Name = "Comprehensive Inpatient Rehabilitation Facility"},
                new ServicePlace {Code = "62", Name = "Comprehensive Outpatient Rehabilitation Facility"},
                new ServicePlace {Code = "65", Name = "End-Stage Renal Disease Treatment Facility"},
                new ServicePlace {Code = "71", Name = "Public Health Clinic"},
                new ServicePlace {Code = "72", Name = "Rural Health Clinic"},
                new ServicePlace {Code = "81", Name = "Independent Laboratory"},
                new ServicePlace {Code = "99", Name = "Other Place of Service"}
            });
        }

        private void InitPolicyTypes(HippoBillingContext context)
        {
            context.PolicyTypes.AddRange(new PolicyType[]
            {
                new PolicyType() {Id = Guid.NewGuid(), Name = "Auto Insurance"},
                new PolicyType() {Id = Guid.NewGuid(), Name = "Blue Cross Blue Shield"},
                new PolicyType() {Id = Guid.NewGuid(), Name = "ChampVA"},
                new PolicyType() {Id = Guid.NewGuid(), Name = "Commercial insurance"},
                new PolicyType() {Id = Guid.NewGuid(), Name = "DMERC"},
                new PolicyType() {Id = Guid.NewGuid(), Name = "EPO"},
                new PolicyType() {Id = Guid.NewGuid(), Name = "HMO"},
                new PolicyType() {Id = Guid.NewGuid(), Name = "Indeminity Insurance"},
                new PolicyType() {Id = Guid.NewGuid(), Name = "Medicaid"},
                new PolicyType() {Id = Guid.NewGuid(), Name = "Medicaid HMO"},
                new PolicyType() {Id = Guid.NewGuid(), Name = "Medicare Part B"},
                new PolicyType() {Id = Guid.NewGuid(), Name = "Medicare HMO"},
                new PolicyType() {Id = Guid.NewGuid(), Name = "Medicare POS"},
                new PolicyType() {Id = Guid.NewGuid(), Name = "Medicare PPO"},
                new PolicyType() {Id = Guid.NewGuid(), Name = "Medicare Supplement"},
                new PolicyType() {Id = Guid.NewGuid(), Name = "Open Access"},
                new PolicyType() {Id = Guid.NewGuid(), Name = "POS"},
                new PolicyType() {Id = Guid.NewGuid(), Name = "PPO"},
                new PolicyType() {Id = Guid.NewGuid(), Name = "Tricare"},
                new PolicyType() {Id = Guid.NewGuid(), Name = "Workers Compensation"}
            });
        }
    }
}