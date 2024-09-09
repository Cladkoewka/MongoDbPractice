# MongoDB Practice Project

## Description
This project is an .NET Core API that demonstrates the use of MongoDB for managing customer data. It implements basic CRUD operations (Create, Read, Update, Delete) for the `Customer` entity.

## Technologies Used
- .NET Core
- MongoDB

## API Endpoints

### 1. Get All Customers
- **Method:** `GET`
- **URL:** `/api/customer`
- **Response:** 
  - **200 OK**: List of all customers.

### 2. Get Customer by ID
- **Method:** `GET`
- **URL:** `/api/customer/{id}`
- **Response:** 
  - **200 OK**: Customer details.
  - **404 Not Found**: If the customer is not found.

### 3. Add Customer
- **Method:** `POST`
- **URL:** `/api/customer`
- **Body:** Customer object in JSON format.
- **Response:** 
  - **201 Created**: Location of the new customer.

### 4. Update Customer
- **Method:** `PUT`
- **URL:** `/api/customer`
- **Body:** Updated Customer object in JSON format.
- **Response:** 
  - **204 No Content**: If the update is successful.

### 5. Delete Customer
- **Method:** `DELETE`
- **URL:** `/api/customer/{id}`
- **Response:** 
  - **204 No Content**: If the deletion is successful.
