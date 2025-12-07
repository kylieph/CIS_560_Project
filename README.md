# CIS_560_Project_Jewelry_Shop

- An Overview of the Project:
The Blossom Jewelry Boutique is an application -based e-commerce platform specializing in handmade jewelry. The system is designed to serve two primary user groups: customers and administrative staff. For customers, the application provides an intuitive interface to browse, search, and purchase unique jewelry items. For administrators, it offers essential inventory management features, such as the ability to add new products and discontinue existing ones. This dual-function system aims to streamline the shopping experience for users while enabling efficient backend operations for store management.

- Technical Description:
Languages: 
C#, SQL - The application was developed using the IDE, Visual Studio 2022, in the language C#. Our Jewelry Boutique program consists of individual forms for each of the user interfaces. All database information is written in SQL.

Libraries: 
BCrypt.Net-Next - Whether a user is creating an account or logging in, their password will be stored using this library to hash the password into a string that cannot easily be reversed. This ensures that a user’s information is secure in the database.

- System Design:
Clarification:
Our project is composed of 8 separate forms and uses the SQL Server to store the databases. When the project starts up, the first form that is created is the “LoginForm.” Depending on how the user interacts with this form, it will either open up a “CreateForm,” an “AdminForm,” or “CustomerForm.” If the user is prompted to “AdminForm,” they are able to open the “AddingItemForm.” If the user is prompted to “CustomerForm,” they are able to open up “CustomerCartForm,” “ItemInfoForm,” and “ProfileForm.” On each of these forms, the database is accessed in order to find users, gather product information, save customer sales, or view highest sales made by the goldsmith users.

LoginForm: This form is the starting point of the application. Users will be asked to either sign-in with their username or password or create a new account.
CreateForm: This form allows the user to create a new account. They must also add enter in their mailing address when creating an account.
CustomerForm: This form is the homepage for the customer logged in. Here, the customer can view their profile, view the cart, logout, filter by new release, metal type or category. Also, it displays all the products specified by the filters. The user is able to add the item to their cart and click the item for more details.
AdminForm: This form is the homepage for the admin logged in. Here, the admin can add a product, delete a product, view the most popular goldsmiths, view the customers that have spent the most, filter by the most popular items from the past 3 months, or sort the items by the highest price.
CustomerCartForm: This form is the cart containing all the items that a customer has added to their cart. Users are able to add or subtract from the items. The user can click the ‘Checkout’ button to complete a successful transaction.
ItemInfoForm: This form consists of the details regarding a product.
AddingItemForm: This form allows the admin to add products that users are able to purchase.
ProfileForm: This form is for the user to be able to view their email, username, and phone number.

- System Features & Usage
Customer Experience:
 We built a system where as a customer you can view all the products in the inventory. The user can filter the items they want to see by ‘category’, ‘metal type’, and ‘new releases’. The 
Admin experience:
When admins log into the application, they are able to access administrative features. They can generate the most popular items - clicking this button results in a display of the top 10 most popular items with the highest sales.

When the program is initially started, the Login Form page is opened which allows the user to enter their username and password or create a new account. Creating a new account opens a form for the user to enter all of their information and then inserts into the User table. The User information table in our database stores whether each account is an admin or a customer. This decides whether the Customer or Admin Form is opened. When the customer form is opened, all of the products are shown with the option to view more information or add it to the cart.  The user can also open a form showing their profile information and a different form showing their cart information. Inside the cart form, the customer can increase and decrease the item quantities and checkout. Checking out deletes the users cart items and inserts an order. If the Admin form is opened instead, the products are again shown but with the option to delete each item. An admin user can also add new items and filter the items by price and most popular.  Either the customer or admin can log out and be brought back to the Login Form. 


The Blossom Boutique Jewelry Shop written by Kylie Phommasack, Kaitlyn Pritchard, and Tinashe Sekabanja is formatted in the following way:

- Jewelry_Project: contains all the forms and designs for the 8 forms of the project
- Data.sql: contains the insert statements
- FinalProjectCode.sql: contains the entire SQL program
- Procedures.sql: contains the procedures
- Tables.sql: contains the tables
- Project_Report: Includes example functionality & queries used
