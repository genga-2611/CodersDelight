# Coders Delight API Documentation

This API provides endpoints for managing assessments, users, and user assessments in the Coders Delight application.

## Authentication

The API uses JWT (JSON Web Token) authentication. To access protected endpoints, include the JWT token in the Authorization header:
```
Authorization: Bearer {your_token}
```

## Endpoints

### Authentication
- POST /api/auth/login - Login with username and password

### Users
- POST /api/users - Register a new user
- GET /api/users/{id} - Get user by ID
- GET /api/users - Get all users
- PUT /api/users/{id} - Update user
- DELETE /api/users/{id} - Delete user

### Assessments
- POST /api/assessments - Create a new assessment
- GET /api/assessments/{id} - Get assessment by ID
- GET /api/assessments - Get all assessments
- PUT /api/assessments/{id} - Update assessment
- DELETE /api/assessments/{id} - Delete assessment

### User Assessments
- POST /api/userassessments - Submit an assessment
- GET /api/userassessments/{id} - Get user assessment by ID
- GET /api/userassessments/user/{userId} - Get assessments for a specific user
- GET /api/userassessments/assessment/{assessmentId} - Get all submissions for a specific assessment

## Models

### User
```json
{
  "id": 0,
  "username": "string",
  "password": "string",
  "isAdmin": false
}
```

### Assessment
```json
{
  "id": 0,
  "title": "string",
  "isMandatory": false,
  "questions": []
}
```

### UserAssessment
```json
{
  "id": 0,
  "userId": 0,
  "assessmentId": 0,
  "score": 0
}
```