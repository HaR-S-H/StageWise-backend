# StageWise -- Project Progress Tracking System (Backend)

## Overview

**StageWise** is a backend system designed for academic institutions to
track and manage student project progress in a structured and
transparent way.

In many colleges, once projects are assigned there is no proper system
to verify whether students are actually working on their projects. This
sometimes leads to students copying projects from external sources
without genuine learning.

**StageWise** solves this problem by introducing a **stage‑based
workflow**, where each project is divided into multiple stages
representing real development milestones. Teachers, mentors, and
department heads can track progress, review submissions, and guide
students throughout the project lifecycle.

------------------------------------------------------------------------

# Key Idea

Every project progresses through predefined stages such as:

-   Project Proposal
-   Requirement Analysis
-   System Design
-   Implementation
-   Testing
-   Final Submission

Students submit updates for each stage while mentors and faculty review
and approve them.

------------------------------------------------------------------------

# Core Features

## Authentication & Authorization

-   Secure authentication using **JWT (JSON Web Tokens)**
-   Role-based access control
-   Separate roles such as **Admin and HOD**

## Department Management

-   Create departments
-   Assign HODs to departments
-   Activate or deactivate departments

## HOD Management

-   Create and update HOD accounts
-   Assign departments
-   Manage HOD status

## Project Tracking

-   Create projects
-   Track stage-based progress
-   Monitor submission timelines

## File Storage

-   Upload project documents and reports
-   Secure storage using **AWS S3**

------------------------------------------------------------------------

# Architecture

The project follows a **layered architecture** to keep the code clean
and maintainable.

Controller Layer\
Handles HTTP requests and responses.

Service Layer\
Contains the business logic of the application.

Repository Layer\
Handles database access and queries.

Database Layer\
Stores application data.

------------------------------------------------------------------------

# Technology Stack

## Backend

-   C#
-   ASP.NET Core Web API
-   Entity Framework Core

## Authentication

-   JWT (JSON Web Token)

## Database

-   SQL Server

## Caching

-   Redis

## Messaging

-   RabbitMQ

## Cloud Storage

-   AWS S3

## API Documentation

-   Swagger / OpenAPI

------------------------------------------------------------------------

# External Integrations

## Redis

Redis is used for caching frequently accessed data to improve API
performance and reduce database load.

## RabbitMQ

RabbitMQ is used for asynchronous messaging and background task
processing.

## AWS S3

AWS S3 is used for storing files such as project documents and reports
securely.

------------------------------------------------------------------------

# Authentication Flow

1.  User sends email and password to login endpoint
2.  Credentials are validated
3.  Server generates a JWT token
4.  Client stores token
5.  Client sends token in Authorization header for protected APIs

Example:

Authorization: Bearer `<JWT_TOKEN>`{=html}

------------------------------------------------------------------------


# Future Improvements

-   Email notification system
-   AI based plagiarism detection
-   Real-time stage updates
-   Docker support
-   CI/CD integration

------------------------------------------------------------------------

# Author

Harsh Gupta\
Backend Developer
