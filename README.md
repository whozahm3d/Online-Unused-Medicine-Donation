# 💊 Unused Medicine Donation System

The Unused Medicine Donation System is a desktop-based C# Windows Forms application designed to streamline the process of donating unused medicines. It allows users to register, log in, and donate medicine through an intuitive interface. Admins have the authority to review, approve, or reject donations. Unlike database-backed systems, this application stores all information — including user credentials, medicine records, inventory, and feedback — in plain .txt files, making it lightweight and portable. The system is especially useful for small-scale community health projects, NGOs, or academic environments where ease of deployment is prioritized over complex setup. Developed as a semester project at FAST-NUCES, it demonstrates modular Windows Forms programming, event-driven UI handling, and basic file-based data management in C#.

---

## ✨ Key Features

- 🔐 Secure User Registration & Login  
- 💊 Submit and Manage Medicine Donations  
- 📦 View and Track Inventory  
- ✅ Admin Panel for Approving/Rejecting Donations  
- 💬 Feedback Collection  
- 💾 Plain Text File Storage  
- 🖥️ Modular UI with Windows Forms  

---

## 🛠️ Tech Stack

- **Language:** C#  
- **Framework:** .NET Framework 4.x  
- **UI:** Windows Forms  
- **IDE:** Visual Studio 2019 or newer  
- **Storage:** `.txt` files (no SQL required)

---

## 🚀 Getting Started

### ✅ Prerequisites

- Visual Studio 2019 or later  
- .NET Framework Developer Pack (v4.7 or higher)

### 🔧 Setup Instructions

1. **Open Project**  
   Navigate to the `se porject/` folder and open `MedicineDonationApp.csproj` in Visual Studio.

2. **Build Solution**  
   Use `Ctrl + Shift + B` or go to `Build > Build Solution`.

3. **Run Application**  
   Press `F5` or click `Start` to launch the program.

> **Note:** All application data (users, donations, feedback) is stored locally in `.txt` files.

---

## 📁 Project Structure

```plaintext
unused-medicine-donation-system/
├── se porject/
│   ├── LoginForm.cs                # User login logic
│   ├── DonateForm.cs               # Form to submit medicine donations
│   ├── FeedbackForm.cs             # Feedback submission form
│   ├── AdminApprovalForm.cs        # Admin approval/rejection panel
│   ├── InventoryForm.cs            # Inventory display form
│   ├── MainForm.cs                 # Application dashboard and navigation
│   ├── App.config                  # Configuration file
│   ├── *.Designer.cs               # UI layout files
│   ├── *.resx                      # Resource files for forms
│   └── *.txt                       # Text files for storing all data
│
├── LICENSE                         # MIT License
├── README.md                       # Project documentation
└── .gitignore                      # Git ignore rules for Visual Studio
