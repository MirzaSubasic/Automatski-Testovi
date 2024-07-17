# Automatski-Testovi

### Tehnologije

.NET 8.0  
Selenium WebDriver 4  
NUnit  

### Packages

coverlet.collector (6.0.0)  
DotNetSeleniumExtras.PageObjects.Core (4.14.1)  
ExentReports (4.1.0)  
Microsoft.NET.Test.Sdk (17.10.0)   
NUnit (4.1.0)   
NUnit.Analysers (4.2.0)   
NUnit3TestAdapter (4.5.0)   
Selenium.Support (4.22.0)   
Selenium.WebDriver (4.22.0)   
Selenium.WebDriver.ChromeDriver (126.0.6478.12600)  


### Demo stranica
https://www.saucedemo.com/ 


### Kratki opis koda  
Prilokom razvoja koda za testiranje korišten je Page Object Model (POM) design patern.  

Pages folder sadrži fajlove koji upravljaju pojedinačnim stranicama u demo stranici. BaseClass.cs sadrži osnovna mapiranja za svako dugme i input polje koje se trenutno koristi u testovima.  

U Static elements folderu je fajl sa svim testnim podacima koji se koriste u testovima i ne bi se trebali mijenjati. 

U Tests folderu su svi testovi. DriverSetup.cs je bazna klasa koju extendaju testovi i koristi se za postavljanje drajvera. BasicWorkflowTests.cs predstavlja osnovni put ili "Happy path". Kreće sa log in, odabirom itema, odlazak u korpu, kupovina odabranog itema i vraćanje na home page.  

ExentReports se koristi za pravljenje test reporta. Trenuno je konfigurisano da se report pravi u downloads folderu.  
