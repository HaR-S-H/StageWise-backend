# StageWise – Project Progress Tracking System (Backend)

##  Overview  
**StageWise** is a project tracking system designed for academic institutions to monitor student project development in a structured and transparent way.

In many colleges, once projects are assigned, there is no proper system to track whether students are genuinely working on them. As a result, some students copy projects from GitHub or other platforms without real learning or contribution. **StageWise** addresses this problem by introducing a *stage-based project workflow*, where each stage represents a meaningful step in the project’s development.

This allows **teachers and mentors** to:
- Track individual student progress
- Verify originality and consistency of work
- Identify delays or issues early
- Provide timely guidance and feedback  

---

##  Key Idea  
Every project is divided into multiple **stages**, each representing a specific milestone in the development process (e.g., idea submission, design, implementation, testing, final submission).

Students update their progress stage by stage, while faculty can monitor, review, and evaluate their work throughout the project lifecycle.

---

##  Backend Implementation  

This repository contains the **backend** for StageWise.

###  Features Implemented (Day 1)
**Date:** 13-01-2026  

- Created a clean and scalable **folder structure**
- Implemented core **models** (e.g., `Student`)
- Added **data validation** using  
  `System.ComponentModel.DataAnnotations` to ensure:
  - Required fields are enforced  
  - Input formats are validated  
  - Data integrity is maintained  

---

##  Project Structure  
The project follows a well-organized backend architecture with separate layers for:
- Models  
- Controllers  
- Services (if applicable)  
- Data Access / Database Context  
- Configuration  

This ensures maintainability, readability, and easy future expansion.

---

##  Purpose of the Project  
StageWise is built as a **college project** with a real-world problem statement:

> *To provide a transparent, structured, and trackable system for monitoring student project development and preventing plagiarism or last-minute submissions.*

---

##  Future Enhancements (Planned)
- Role-based access (Student / Mentor / Admin)
- Project stage management
- Progress reports and analytics
- File submissions and version tracking
- Plagiarism detection integration

---

##  Author  
**Harsh Gupta**  
Backend Developer – StageWise Project  
