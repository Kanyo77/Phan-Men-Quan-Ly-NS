## 📌 Giới thiệu

Đây là một phần mềm desktop giúp quản lý toàn bộ quy trình nhân sự của một doanh nghiệp, từ lúc ứng viên đăng ký đến khi nhân viên kết thúc làm việc. Phần mềm được phát triển với ngôn ngữ C# trên nền WinForms và sử dụng cơ sở dữ liệu PostgreSQL. Hệ thống hỗ trợ quản lý thông tin nhân sự, chấm công, tính lương và in báo cáo.

![Screenshot6](https://github.com/Kanyo77/Phan-Men-Quan-Ly-NS/blob/90d7eec900d5e8736d76a9d47d05d362b04ffe7a/Screenshot3.png)

## 🧩 Các tính năng chính

### 👨‍💻 1. Đăng nhập hệ thống
- Giao diện đăng nhập dành cho Admin/User
- Kiểm tra thông tin hợp lệ và điều hướng chức năng tương ứng

### 🔐 2. Đăng ký ứng viên
- Giao diện cho ứng viên nhập thông tin cá nhân
- Cho phép thêm, sửa, xóa thông tin ứng viên trước khi duyệt

### ✅ 3. Duyệt ứng viên trở thành nhân viên chính thức
- Chuyển đổi dữ liệu từ bảng ứng viên sang nhân viên
- Gán mức lương và phòng ban phù hợp

### 💰 4. Tính lương
- Tự động tính số ngày làm việc
- Tính lương dựa trên số ngày làm và mức lương cơ bản
- Cập nhật, lưu và in báo cáo bảng lương

### 📄 5. In báo cáo
- Xuất báo cáo ứng viên, nhân viên và bảng lương
- Cho phép lọc dữ liệu và in phiếu lương chi tiết

---

## 🛠️ Công nghệ sử dụng

| Thành phần              | Công nghệ                     |
|-------------------------|-------------------------------|
| Ngôn ngữ lập trình      | C# (WinForms)                 |
| Database                | PostgreSQL                    |
| IDE                     | Visual Studio 2019            |
| Cloud Storage (hình ảnh)| Cloudinary                    |
| Framework               | .NET Framework                |

---

## 🧱 Cấu trúc CSDL (chính)

- `BL_NhanVien` – bảng lương
- `DangNhap` – thông tin đăng nhập
- `TTUngVien` – thông tin ứng viên
- `TT_NhanVien` – thông tin nhân viên
- `QuocTich`, `PhongBan`, `DanToc`, `TonGiao` – bảng phụ cho combobox

---

## 📷 Một số giao diện
![Screenshot1](https://github.com/Kanyo77/Phan-Men-Quan-Ly-NS/blob/90d7eec900d5e8736d76a9d47d05d362b04ffe7a/Screenshot1.png)

![Screenshot2](https://github.com/Kanyo77/Phan-Men-Quan-Ly-NS/blob/90d7eec900d5e8736d76a9d47d05d362b04ffe7a/Screenshot2.png)

![Screenshot6](https://github.com/Kanyo77/Phan-Men-Quan-Ly-NS/blob/90d7eec900d5e8736d76a9d47d05d362b04ffe7a/Screenshot6.png)

![Screenshot4](https://github.com/Kanyo77/Phan-Men-Quan-Ly-NS/blob/90d7eec900d5e8736d76a9d47d05d362b04ffe7a/Screenshot4.png)

![Screenshot5](https://github.com/Kanyo77/Phan-Men-Quan-Ly-NS/blob/90d7eec900d5e8736d76a9d47d05d362b04ffe7a/Screenshot5.png)

---

## 🚀 Hướng dẫn chạy thử

1. Clone repo về máy
2. Mở bằng Visual Studio 2019
3. Cài đặt PostgreSQL (nếu chưa có)
4. Import CSDL (file `.sql` nếu có, chưa thấy đính kèm trong repo)
5. Chạy chương trình (WinForms)


## 💡 Ghi chú

- Đây là đồ án môn học, nhưng đã mô phỏng được quy trình quản lý nhân sự cơ bản của một doanh nghiệp nhỏ.
- Dự án có thể được mở rộng để kết nối web hoặc nâng cấp lên nền tảng đa thiết bị.

