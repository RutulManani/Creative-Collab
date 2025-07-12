# EduFitMart – Creative Collaboration Project

## 1. 💡 Collaboration Project Concept

**EduFitMart** is a unified platform that brings together three powerful Content Management Systems - **fitness tracking**, **school management**, and **e-commerce**, into one integrated ecosystem designed for educational institutions.

This project merges each team member’s passion project to deliver a holistic student platform that enhances academic experience, promotes physical well-being, and incentivizes achievements through rewards.

### 🔗 Core Modules:
- **Admins** can manage students, courses, and enrollments (Mahak’s system)  
- **Students** can plan workouts, track exercises, and manage fitness goals (Rutul’s system)  
- **Students & Staff** can access a reward-based gifting platform to purchase wellness items (Priyank’s system)

The collaboration creates a seamless experience that empowers institutions to support student success in academics, health, and motivation.

---

## 2. 🗃️ Entity Relationship Diagram (ERD)

The unified ERD includes:
- `Student` (central entity)
- `Enrollment`, `Course` – Academic records  
- `Workout`, `Exercise`, `Equipment` – Fitness tracking  
- `Order`, `Product` – E-commerce gifting  

### 🧩 Base Entities + CRUD Operations

#### 🧑‍🎓 Student
- Create, Read, Update, Delete  
- ListWorkoutsForStudent  
- ListOrdersForStudent  
- ListCoursesForStudent  

#### 🏋️‍♂️ Workout
- Create, Read, Update, Delete  
- ListExercisesForWorkout  
- ListStudentsForWorkout  

#### 🏫 Course
- Create, Read, Update, Delete  
- ListStudentsForCourse  

#### 🏃 Exercise
- Create, Read, Update, Delete  
- ListWorkoutsForExercise  
- ListEquipmentForExercise  

#### 🛠️ Equipment
- Create, Read, Update, Delete  
- ListExercisesForEquipment  

#### 📦 Product
- Create, Read, Update, Delete  
- ListOrdersForProduct  

#### 📬 Order
- Create, Read, Update, Delete  
- ListProductsForOrder  
- ListOrdersForStudent  

---

### 🔁 Related CRUD Operations

#### Student ↔ Workout (M:M)
- LinkWorkoutToStudent  
- UnlinkWorkoutFromStudent  
- ListWorkoutsForStudent  
- ListStudentsForWorkout  

#### Workout ↔ Exercise (M:M)
- LinkExerciseToWorkout  
- UnlinkExerciseFromWorkout  
- ListExercisesForWorkout  
- ListWorkoutsForExercise  

#### Exercise ↔ Equipment (M:M)
- LinkEquipmentToExercise  
- UnlinkEquipmentFromExercise  
- ListEquipmentForExercise  
- ListExercisesForEquipment  

#### Student ↔ Course (M:M via Enrollment)
- EnrollStudentInCourse  
- RemoveStudentFromCourse  
- ListCoursesForStudent  
- ListStudentsForCourse  

#### Order ↔ Product (M:M via OrderItem)
- AddProductToOrder  
- RemoveProductFromOrder  
- ListProductsForOrder  
- ListOrdersForProduct  

#### Student → Order (1:M)
- ListOrdersForStudent  

---

## 3. 🖼️ Wireframes

We are designing wireframes for the following:

### Admin Interfaces
- Students, Courses, Enrollments  
- Workouts, Exercises, Equipment  
- Vendors, Products, Orders  

### Student Dashboard
- Course & Workout Overview  
- Fitness Progress Tracker  
- “Gift Store” for redeeming rewards  

👉 **[View Wireframes](#)** *(Insert PNG or Figma link here)*

---

## 4. 📅 Project Schedule

| Milestone                            | Deadline        |
|-------------------------------------|-----------------|
| New GitHub Repository Created       | July 11, 2025   |
| Unified ERD + Wireframes Finalized  | July 17, 2025   |
| Database + Models Built             | July 20, 2025   |
| CRUD for Individual MVPs Loaded     | July 22, 2025   |
| Initial Collaboration Connections   | July 26, 2025   |
| Full Creative Collab MVP            | Aug 1, 2025     |
| Admin-Only Features Implemented     | Aug 5, 2025     |
| Extra Features Integrated           | Aug 8, 2025     |
| Testing + Debugging                 | Aug 10, 2025    |
| Final Submission + Documentation    | Aug 12, 2025    |

### 🕒 Team Meetings
- **Zoom Calls:** Mondays & Fridays at 6 PM  
- **WhatsApp Check-ins:** Daily  

---

## 5. 🛠 Troubleshooting Strategies

| Issue                          | Strategy                                                                 |
|-------------------------------|--------------------------------------------------------------------------|
| **Migration Errors**          | Roll back, recheck fluent API annotations, and rebuild from clean state |
| **Git Conflicts**             | Assign merge roles; resolve via VSCode Live Share if needed              |
| **CRUD not working (Web API)**| Use Swagger to test endpoints individually                   |
| **Views Not Rendering**       | Inspect view models, controller-returned models, and route paths         |
| **Broken Relationships (M:M)**| Use `.Include().ThenInclude()` and verify correct junction table mapping |

---

🧠 *This project is a collaboration between Mahak Patel, Rutul Manani, and Priyank Shah for HTTP-5226 – Back-End Web Development II (Humber College).*
