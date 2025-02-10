# 🎨 FrameSphere - A Platform for Virtual Events 🌍✨

FrameSphere is a **desktop application** that revolutionizes the way users engage with **virtual events**, particularly **art exhibitions**. Our platform enables users to **explore**, **host**, and **participate** in immersive **3D exhibitions**, allowing artists to showcase their creative work to a **global audience**. 🖼️🚀

---

## 📌 Features & User Roles

### 🏛️ **User**
- 🔍 **View Art** in live & past exhibitions
- 📅 **Discover ongoing & upcoming events**
- 📝 **Register for Events**
- 🎨 **Bid/Purchase Art**
- 💬 **Communicate with Artists**

### 🎭 **Artist**
- 🖌️ **Upload Art** (Paintings, 3D Models)
- 🏷️ **Sell Art** (Fixed Price / Bidding)
- 📢 **Engage with Visitors & Collectors**

### 🎟️ **Organizer**
- 🎪 **Create & Manage Events**
- ✅ **Approve Artists for Events**
- 🎫 **Sell Event Tickets**

### 🛠️ **Admin**
- 🏛️ **Approve/Reject User Registrations**
- ✅ **Approve/Reject Events & Art Uploads**
- 🔧 **Manage the Entire Platform**

---

## 🏗️ **Tech Stack**
- 🚀 **Frontend**: C# (.NET WPF)  
- 🛢 **Database**: Microsoft SQL Server  
- 📁 **Data Handling**: JSON for storing dynamic content  
- 🎮 **3D Rendering**: Unity (for immersive experiences)

---

## 🖥️ **System Architecture**
🔹 **Database Structure**
- **Users**: Stores user profiles & permissions
- **Events**: Maintains event details & schedules
- **Art**: Handles uploaded artworks & selling options
- **User Interactions**: Tracks purchases, messages, and event participation

🔹 **Class Diagrams**
- 🎨 Art: Attributes like title, description, images
- 🎟️ Event: Attributes like title, organization, ticket price
- 👤 User: Manages profile & authentication

---

## 📖 **Installation Guide**
Follow these steps to set up FrameSphere on your local machine:

```sh
# Clone the repository
git clone https://github.com/muin99/FrameSphere.git

# Navigate to the project directory
cd FrameSphere

# Import the Data Tier application from Database folder into your Microsoft SQL Server
FrameSphere

# From DBConnect.cs class, change the server name according to your server
private static readonly string ServerName = "your-server-name"

# Run the application (ensure dependencies are installed)
run

# Admin account for this system is 
    username: admin
    password: admin
```

---

## 📜 **Future Roadmap**
✅ **Phase 1**: Basic CRUD operations for Users, Events, and Art  
✅ **Phase 2**: Implementing Bidding System  
🔜 **Phase 3**: 3D Exhibition Environment in Unity  
🔜 **Phase 4**: Advanced AI-based Art Recommendations  

---

## 🌟 **Project Contributions**

### 👑 **Project Head: Mohammad Muin (Onukrom)**
Hey everyone, I’m **Muin(aka Onukrom)**, the **Project Leader** of FrameSphere. I led the entire project, handling **most of the development and architectural decisions**. This journey was a challenging yet rewarding experience, and I’m proud of what we’ve built! 🚀✨

🔗 **GitHub**: [github.com/muin99](https://github.com/muin99)  
🌐 **Website**: [onukrom.xyz](https://onukrom.xyz)  

---

### 💡 **Contributors**

🔹 **Raisa & Nabil** – Your support and dedication to this project were invaluable! Without you, this project would not have been possible to complete. You both were amazing to work with. Keep up the great work! 🎨🔥

🔗 **Nabil’s GitHub**: [github.com/Mazharul75](https://github.com/Mazharul75)  
🔗 **Raisa’s GitHub**: [github.com/raisa385](https://github.com/raisa385)  


---

## 🤝 **Contributing**
We welcome contributions! Follow these steps to contribute:

1. **Fork** the repository
2. **Create** a feature branch (`git checkout -b feature-branch`)
3. **Commit** your changes (`git commit -m "Add new feature"`)
4. **Push** to your branch (`git push origin feature-branch`)
5. **Open a Pull Request** 🎉

---

## 🛡️ **License**
This project is Open to all. No copyright!

---

## 📬 **Contact Us**
📧 Email: 56muin@example.com  
📌 GitHub Issues: [Report Issues Here](https://github.com/muin99/FrameSphere/issues)  

Let's **redefine the future of virtual events** together! 🚀🎨✨
