## WEEK 11 Understanding the .NET Framework

Thois week we were tasked to create a customer poral using the dotnet portal the portal can be found here : https://rocket-elevators-tk-customer-portal.azurewebsites.net/

The Portal is comprised of a landing page  in views INDEX. for the moment it is filled with random text from the template i used and a graph section can be used to display customer specific information.

by following the links in he nav bar the customer can reach the product management section or the interventionform and also change his password.

## Registration
registration is limmitted to customers by email from the mysql database: here are some addresses that can be added  to the registry : 

- zetta.volkman@bailey.org
- lashawn@simonis.org
- tanner@wisozk.org
- burt.block@wehner.info
- leonila@prohaska.org
- colby.cremin@bashirian.name
- clement.mohr@wuckert.com
- ara_bogisich@zemlak.name
- bettina@gislason-rolfson.net
- bud@pouros-runte.com
- dean@sauer.name
- treva@oberbrunner.co
- phung.carter@bins.org
- lillie.mosciski@stroman.net
- mattie@emmerich.info
- yasmine@bednar.io
- deangelo@schinner.io
- wally@graham-fritsch.biz
- stevie@metz.biz 




## Product management:

the products view is dependant on its controller and will use classes from the different product models : building,batterie,column,elevator.

on landing on the page the customer can view their information. and a submit button allows them to navigate to an update information page. from they can change their informatiion.

otherwise they can select different products and display their information and if necessary request qnd intervention on the product with a prefilled form .
## Intervention form
The intervention form uses code form rocket elevators foundation that has been adapted to c# and .NET Core. also it has been modified to have prefilled fields with the customer information.

all this has been made possible with the Rest API : 

you can find here : https://github.com/trevorius/Rocket-RestAPI.git
for which more end points have been adapted.
