# Application README

## Running the Application

To run the application, follow these steps:

1. Build the Docker images with no cache:
   ```sh
   docker-compose build --no-cache
   ```

2. Start the application:
   ```sh
   docker-compose up
   ```

## Known Issues and Limitations

### Backend (BE)

- **User Class Attributes**: The `User` class contains attributes that should not be there, such as filters. Ideally, filters should be associated with the `User` ID, and we would fetch them accordingly. This approach was used for expediency.
  
- **Filtering**: The `GetAllFilteredProductsAsync` method could be improved. A factory pattern was considered but not implemented due to time constraints. 

- **Missing Features**: The backend is incomplete. The order functionality is missing, and there are bugs related to word filtering. 

**Development Time for Backend**: 4 hours

### Frontend (FE)

- **Incomplete Features**: The frontend implementation is incomplete, and various features were not fully developed.

**Development Time for Frontend**: 2 hours

## Conclusion

Due to time constraints, several features are incomplete, and there are known issues in both the backend and frontend components. Future work is needed to address these limitations and enhance the functionality of the application.
