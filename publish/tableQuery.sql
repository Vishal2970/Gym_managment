CREATE TABLE gymManagement (
    Id INT PRIMARY KEY,
    Name VARCHAR(100),
    MobileNumber VARCHAR(15),
    AadharNumber VARCHAR(20),
    MemberShipDate DATE,
    FeesPayed DATE
);

select * from gymManagement
--hardcode update
update gymManagement set FeesPayed='2025-2-20' where Id='7';