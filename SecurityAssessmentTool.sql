create database VulnerabilityRuleMatrix;



CREATE TABLE VulnerabilityRuleMatrix.ProgrammingFeature (
iPFID int PRIMARY KEY AUTO_INCREMENT,
cPFDescription varchar(225) NOT NULL,
cRegExp varchar(225) NOT NULL,
cPLanguage varchar(25) NOT NULL,
cRCD_DEL char default 'N'
);

create table VulnerabilityRuleMatrix.FeatureRule (
iRuleID int PRIMARY KEY AUTO_INCREMENT,
cRuleDescription varchar(225) NOT NULL,
cRiskSeverity varchar(25) NOT NULL,
cRuleSolution varchar(225) NOT NULL,
cRCD_DEL char default 'N'
);


create table VulnerabilityRuleMatrix.ValidationStep (
iValidationID int PRIMARY KEY AUTO_INCREMENT,
cValidationOrder int NOT NULL,
cRegExp varchar(225) NOT NULL,
cScope varchar(25) NOT NULL,
cRCD_DEL char default 'N'
);

create table VulnerabilityRuleMatrix.PF_FR_Rel (
iPF_FR_Rel_ID int PRIMARY KEY AUTO_INCREMENT,
iPFID int,
iRuleID int,
FOREIGN KEY (iPFID) REFERENCES ProgrammingFeature(iPFID),
FOREIGN KEY (iRuleID) REFERENCES FeatureRule(iRuleID),
cRCD_DEL char default 'N'
);

create table VulnerabilityRuleMatrix.FR_VS_Rel (
iFR_VS_Rel_ID int PRIMARY KEY AUTO_INCREMENT,
iRuleID int,
FOREIGN KEY (iRuleID) REFERENCES FeatureRule(iRuleID),
iValidationID int,
FOREIGN KEY (iValidationID) REFERENCES ValidationStep(iValidationID),
cRCD_DEL char default 'N'
);