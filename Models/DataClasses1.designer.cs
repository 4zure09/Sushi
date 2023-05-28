﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sushi.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="DACS")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertChiTietDonHang(ChiTietDonHang instance);
    partial void UpdateChiTietDonHang(ChiTietDonHang instance);
    partial void DeleteChiTietDonHang(ChiTietDonHang instance);
    partial void InsertTaiKhoan(TaiKhoan instance);
    partial void UpdateTaiKhoan(TaiKhoan instance);
    partial void DeleteTaiKhoan(TaiKhoan instance);
    partial void InsertDonDatHang(DonDatHang instance);
    partial void UpdateDonDatHang(DonDatHang instance);
    partial void DeleteDonDatHang(DonDatHang instance);
    partial void InsertKhachHang(KhachHang instance);
    partial void UpdateKhachHang(KhachHang instance);
    partial void DeleteKhachHang(KhachHang instance);
    partial void InsertNhanVien(NhanVien instance);
    partial void UpdateNhanVien(NhanVien instance);
    partial void DeleteNhanVien(NhanVien instance);
    partial void InsertSushi(Sushi instance);
    partial void UpdateSushi(Sushi instance);
    partial void DeleteSushi(Sushi instance);
    #endregion
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<ChiTietDonHang> ChiTietDonHangs
		{
			get
			{
				return this.GetTable<ChiTietDonHang>();
			}
		}
		
		public System.Data.Linq.Table<TaiKhoan> TaiKhoans
		{
			get
			{
				return this.GetTable<TaiKhoan>();
			}
		}
		
		public System.Data.Linq.Table<DonDatHang> DonDatHangs
		{
			get
			{
				return this.GetTable<DonDatHang>();
			}
		}
		
		public System.Data.Linq.Table<KhachHang> KhachHangs
		{
			get
			{
				return this.GetTable<KhachHang>();
			}
		}
		
		public System.Data.Linq.Table<NhanVien> NhanViens
		{
			get
			{
				return this.GetTable<NhanVien>();
			}
		}
		
		public System.Data.Linq.Table<Sushi> Sushis
		{
			get
			{
				return this.GetTable<Sushi>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ChiTietDonHang")]
	public partial class ChiTietDonHang : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID_ChiTiet;
		
		private System.Nullable<int> _ID_DonHang;
		
		private System.Nullable<int> _ID_Sushi;
		
		private System.Nullable<int> _SoLuong;
		
		private EntityRef<DonDatHang> _DonDatHang;
		
		private EntityRef<Sushi> _Sushi;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnID_ChiTietChanging(int value);
    partial void OnID_ChiTietChanged();
    partial void OnID_DonHangChanging(System.Nullable<int> value);
    partial void OnID_DonHangChanged();
    partial void OnID_SushiChanging(System.Nullable<int> value);
    partial void OnID_SushiChanged();
    partial void OnSoLuongChanging(System.Nullable<int> value);
    partial void OnSoLuongChanged();
    #endregion
		
		public ChiTietDonHang()
		{
			this._DonDatHang = default(EntityRef<DonDatHang>);
			this._Sushi = default(EntityRef<Sushi>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_ChiTiet", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID_ChiTiet
		{
			get
			{
				return this._ID_ChiTiet;
			}
			set
			{
				if ((this._ID_ChiTiet != value))
				{
					this.OnID_ChiTietChanging(value);
					this.SendPropertyChanging();
					this._ID_ChiTiet = value;
					this.SendPropertyChanged("ID_ChiTiet");
					this.OnID_ChiTietChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_DonHang", DbType="Int")]
		public System.Nullable<int> ID_DonHang
		{
			get
			{
				return this._ID_DonHang;
			}
			set
			{
				if ((this._ID_DonHang != value))
				{
					if (this._DonDatHang.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnID_DonHangChanging(value);
					this.SendPropertyChanging();
					this._ID_DonHang = value;
					this.SendPropertyChanged("ID_DonHang");
					this.OnID_DonHangChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_Sushi", DbType="Int")]
		public System.Nullable<int> ID_Sushi
		{
			get
			{
				return this._ID_Sushi;
			}
			set
			{
				if ((this._ID_Sushi != value))
				{
					if (this._Sushi.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnID_SushiChanging(value);
					this.SendPropertyChanging();
					this._ID_Sushi = value;
					this.SendPropertyChanged("ID_Sushi");
					this.OnID_SushiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SoLuong", DbType="Int")]
		public System.Nullable<int> SoLuong
		{
			get
			{
				return this._SoLuong;
			}
			set
			{
				if ((this._SoLuong != value))
				{
					this.OnSoLuongChanging(value);
					this.SendPropertyChanging();
					this._SoLuong = value;
					this.SendPropertyChanged("SoLuong");
					this.OnSoLuongChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="DonDatHang_ChiTietDonHang", Storage="_DonDatHang", ThisKey="ID_DonHang", OtherKey="ID_DonHang", IsForeignKey=true)]
		public DonDatHang DonDatHang
		{
			get
			{
				return this._DonDatHang.Entity;
			}
			set
			{
				DonDatHang previousValue = this._DonDatHang.Entity;
				if (((previousValue != value) 
							|| (this._DonDatHang.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._DonDatHang.Entity = null;
						previousValue.ChiTietDonHangs.Remove(this);
					}
					this._DonDatHang.Entity = value;
					if ((value != null))
					{
						value.ChiTietDonHangs.Add(this);
						this._ID_DonHang = value.ID_DonHang;
					}
					else
					{
						this._ID_DonHang = default(Nullable<int>);
					}
					this.SendPropertyChanged("DonDatHang");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Sushi_ChiTietDonHang", Storage="_Sushi", ThisKey="ID_Sushi", OtherKey="ID_Sushi", IsForeignKey=true)]
		public Sushi Sushi
		{
			get
			{
				return this._Sushi.Entity;
			}
			set
			{
				Sushi previousValue = this._Sushi.Entity;
				if (((previousValue != value) 
							|| (this._Sushi.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Sushi.Entity = null;
						previousValue.ChiTietDonHangs.Remove(this);
					}
					this._Sushi.Entity = value;
					if ((value != null))
					{
						value.ChiTietDonHangs.Add(this);
						this._ID_Sushi = value.ID_Sushi;
					}
					else
					{
						this._ID_Sushi = default(Nullable<int>);
					}
					this.SendPropertyChanged("Sushi");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TaiKhoan")]
	public partial class TaiKhoan : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID_TaiKhoan;
		
		private System.Nullable<int> _ID_KhachHang;
		
		private string _TenDangNhap;
		
		private string _MatKhau;
		
		private EntityRef<KhachHang> _KhachHang;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnID_TaiKhoanChanging(int value);
    partial void OnID_TaiKhoanChanged();
    partial void OnID_KhachHangChanging(System.Nullable<int> value);
    partial void OnID_KhachHangChanged();
    partial void OnTenDangNhapChanging(string value);
    partial void OnTenDangNhapChanged();
    partial void OnMatKhauChanging(string value);
    partial void OnMatKhauChanged();
    #endregion
		
		public TaiKhoan()
		{
			this._KhachHang = default(EntityRef<KhachHang>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_TaiKhoan", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID_TaiKhoan
		{
			get
			{
				return this._ID_TaiKhoan;
			}
			set
			{
				if ((this._ID_TaiKhoan != value))
				{
					this.OnID_TaiKhoanChanging(value);
					this.SendPropertyChanging();
					this._ID_TaiKhoan = value;
					this.SendPropertyChanged("ID_TaiKhoan");
					this.OnID_TaiKhoanChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_KhachHang", DbType="Int")]
		public System.Nullable<int> ID_KhachHang
		{
			get
			{
				return this._ID_KhachHang;
			}
			set
			{
				if ((this._ID_KhachHang != value))
				{
					if (this._KhachHang.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnID_KhachHangChanging(value);
					this.SendPropertyChanging();
					this._ID_KhachHang = value;
					this.SendPropertyChanged("ID_KhachHang");
					this.OnID_KhachHangChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenDangNhap", DbType="NVarChar(50)")]
		public string TenDangNhap
		{
			get
			{
				return this._TenDangNhap;
			}
			set
			{
				if ((this._TenDangNhap != value))
				{
					this.OnTenDangNhapChanging(value);
					this.SendPropertyChanging();
					this._TenDangNhap = value;
					this.SendPropertyChanged("TenDangNhap");
					this.OnTenDangNhapChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MatKhau", DbType="NVarChar(50)")]
		public string MatKhau
		{
			get
			{
				return this._MatKhau;
			}
			set
			{
				if ((this._MatKhau != value))
				{
					this.OnMatKhauChanging(value);
					this.SendPropertyChanging();
					this._MatKhau = value;
					this.SendPropertyChanged("MatKhau");
					this.OnMatKhauChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="KhachHang_TaiKhoan", Storage="_KhachHang", ThisKey="ID_KhachHang", OtherKey="ID_KhachHang", IsForeignKey=true)]
		public KhachHang KhachHang
		{
			get
			{
				return this._KhachHang.Entity;
			}
			set
			{
				KhachHang previousValue = this._KhachHang.Entity;
				if (((previousValue != value) 
							|| (this._KhachHang.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._KhachHang.Entity = null;
						previousValue.TaiKhoans.Remove(this);
					}
					this._KhachHang.Entity = value;
					if ((value != null))
					{
						value.TaiKhoans.Add(this);
						this._ID_KhachHang = value.ID_KhachHang;
					}
					else
					{
						this._ID_KhachHang = default(Nullable<int>);
					}
					this.SendPropertyChanged("KhachHang");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.DonDatHang")]
	public partial class DonDatHang : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID_DonHang;
		
		private System.Nullable<int> _ID_KhachHang;
		
		private System.Nullable<System.DateTime> _NgayDatHang;
		
		private string _TrangThai;
		
		private EntitySet<ChiTietDonHang> _ChiTietDonHangs;
		
		private EntityRef<KhachHang> _KhachHang;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnID_DonHangChanging(int value);
    partial void OnID_DonHangChanged();
    partial void OnID_KhachHangChanging(System.Nullable<int> value);
    partial void OnID_KhachHangChanged();
    partial void OnNgayDatHangChanging(System.Nullable<System.DateTime> value);
    partial void OnNgayDatHangChanged();
    partial void OnTrangThaiChanging(string value);
    partial void OnTrangThaiChanged();
    #endregion
		
		public DonDatHang()
		{
			this._ChiTietDonHangs = new EntitySet<ChiTietDonHang>(new Action<ChiTietDonHang>(this.attach_ChiTietDonHangs), new Action<ChiTietDonHang>(this.detach_ChiTietDonHangs));
			this._KhachHang = default(EntityRef<KhachHang>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_DonHang", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID_DonHang
		{
			get
			{
				return this._ID_DonHang;
			}
			set
			{
				if ((this._ID_DonHang != value))
				{
					this.OnID_DonHangChanging(value);
					this.SendPropertyChanging();
					this._ID_DonHang = value;
					this.SendPropertyChanged("ID_DonHang");
					this.OnID_DonHangChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_KhachHang", DbType="Int")]
		public System.Nullable<int> ID_KhachHang
		{
			get
			{
				return this._ID_KhachHang;
			}
			set
			{
				if ((this._ID_KhachHang != value))
				{
					if (this._KhachHang.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnID_KhachHangChanging(value);
					this.SendPropertyChanging();
					this._ID_KhachHang = value;
					this.SendPropertyChanged("ID_KhachHang");
					this.OnID_KhachHangChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgayDatHang", DbType="Date")]
		public System.Nullable<System.DateTime> NgayDatHang
		{
			get
			{
				return this._NgayDatHang;
			}
			set
			{
				if ((this._NgayDatHang != value))
				{
					this.OnNgayDatHangChanging(value);
					this.SendPropertyChanging();
					this._NgayDatHang = value;
					this.SendPropertyChanged("NgayDatHang");
					this.OnNgayDatHangChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TrangThai", DbType="NVarChar(50)")]
		public string TrangThai
		{
			get
			{
				return this._TrangThai;
			}
			set
			{
				if ((this._TrangThai != value))
				{
					this.OnTrangThaiChanging(value);
					this.SendPropertyChanging();
					this._TrangThai = value;
					this.SendPropertyChanged("TrangThai");
					this.OnTrangThaiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="DonDatHang_ChiTietDonHang", Storage="_ChiTietDonHangs", ThisKey="ID_DonHang", OtherKey="ID_DonHang")]
		public EntitySet<ChiTietDonHang> ChiTietDonHangs
		{
			get
			{
				return this._ChiTietDonHangs;
			}
			set
			{
				this._ChiTietDonHangs.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="KhachHang_DonDatHang", Storage="_KhachHang", ThisKey="ID_KhachHang", OtherKey="ID_KhachHang", IsForeignKey=true)]
		public KhachHang KhachHang
		{
			get
			{
				return this._KhachHang.Entity;
			}
			set
			{
				KhachHang previousValue = this._KhachHang.Entity;
				if (((previousValue != value) 
							|| (this._KhachHang.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._KhachHang.Entity = null;
						previousValue.DonDatHangs.Remove(this);
					}
					this._KhachHang.Entity = value;
					if ((value != null))
					{
						value.DonDatHangs.Add(this);
						this._ID_KhachHang = value.ID_KhachHang;
					}
					else
					{
						this._ID_KhachHang = default(Nullable<int>);
					}
					this.SendPropertyChanged("KhachHang");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_ChiTietDonHangs(ChiTietDonHang entity)
		{
			this.SendPropertyChanging();
			entity.DonDatHang = this;
		}
		
		private void detach_ChiTietDonHangs(ChiTietDonHang entity)
		{
			this.SendPropertyChanging();
			entity.DonDatHang = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.KhachHang")]
	public partial class KhachHang : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID_KhachHang;
		
		private string _HoTen;
		
		private string _DiaChi;
		
		private string _SoDienThoai;
		
		private EntitySet<TaiKhoan> _TaiKhoans;
		
		private EntitySet<DonDatHang> _DonDatHangs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnID_KhachHangChanging(int value);
    partial void OnID_KhachHangChanged();
    partial void OnHoTenChanging(string value);
    partial void OnHoTenChanged();
    partial void OnDiaChiChanging(string value);
    partial void OnDiaChiChanged();
    partial void OnSoDienThoaiChanging(string value);
    partial void OnSoDienThoaiChanged();
    #endregion
		
		public KhachHang()
		{
			this._TaiKhoans = new EntitySet<TaiKhoan>(new Action<TaiKhoan>(this.attach_TaiKhoans), new Action<TaiKhoan>(this.detach_TaiKhoans));
			this._DonDatHangs = new EntitySet<DonDatHang>(new Action<DonDatHang>(this.attach_DonDatHangs), new Action<DonDatHang>(this.detach_DonDatHangs));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_KhachHang", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID_KhachHang
		{
			get
			{
				return this._ID_KhachHang;
			}
			set
			{
				if ((this._ID_KhachHang != value))
				{
					this.OnID_KhachHangChanging(value);
					this.SendPropertyChanging();
					this._ID_KhachHang = value;
					this.SendPropertyChanged("ID_KhachHang");
					this.OnID_KhachHangChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HoTen", DbType="NVarChar(255)")]
		public string HoTen
		{
			get
			{
				return this._HoTen;
			}
			set
			{
				if ((this._HoTen != value))
				{
					this.OnHoTenChanging(value);
					this.SendPropertyChanging();
					this._HoTen = value;
					this.SendPropertyChanged("HoTen");
					this.OnHoTenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DiaChi", DbType="NVarChar(255)")]
		public string DiaChi
		{
			get
			{
				return this._DiaChi;
			}
			set
			{
				if ((this._DiaChi != value))
				{
					this.OnDiaChiChanging(value);
					this.SendPropertyChanging();
					this._DiaChi = value;
					this.SendPropertyChanged("DiaChi");
					this.OnDiaChiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SoDienThoai", DbType="NVarChar(20)")]
		public string SoDienThoai
		{
			get
			{
				return this._SoDienThoai;
			}
			set
			{
				if ((this._SoDienThoai != value))
				{
					this.OnSoDienThoaiChanging(value);
					this.SendPropertyChanging();
					this._SoDienThoai = value;
					this.SendPropertyChanged("SoDienThoai");
					this.OnSoDienThoaiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="KhachHang_TaiKhoan", Storage="_TaiKhoans", ThisKey="ID_KhachHang", OtherKey="ID_KhachHang")]
		public EntitySet<TaiKhoan> TaiKhoans
		{
			get
			{
				return this._TaiKhoans;
			}
			set
			{
				this._TaiKhoans.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="KhachHang_DonDatHang", Storage="_DonDatHangs", ThisKey="ID_KhachHang", OtherKey="ID_KhachHang")]
		public EntitySet<DonDatHang> DonDatHangs
		{
			get
			{
				return this._DonDatHangs;
			}
			set
			{
				this._DonDatHangs.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_TaiKhoans(TaiKhoan entity)
		{
			this.SendPropertyChanging();
			entity.KhachHang = this;
		}
		
		private void detach_TaiKhoans(TaiKhoan entity)
		{
			this.SendPropertyChanging();
			entity.KhachHang = null;
		}
		
		private void attach_DonDatHangs(DonDatHang entity)
		{
			this.SendPropertyChanging();
			entity.KhachHang = this;
		}
		
		private void detach_DonDatHangs(DonDatHang entity)
		{
			this.SendPropertyChanging();
			entity.KhachHang = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.NhanVien")]
	public partial class NhanVien : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID_NhanVien;
		
		private string _HoTen;
		
		private System.Nullable<System.DateTime> _NgaySinh;
		
		private string _GioiTinh;
		
		private string _SoDienThoai;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnID_NhanVienChanging(int value);
    partial void OnID_NhanVienChanged();
    partial void OnHoTenChanging(string value);
    partial void OnHoTenChanged();
    partial void OnNgaySinhChanging(System.Nullable<System.DateTime> value);
    partial void OnNgaySinhChanged();
    partial void OnGioiTinhChanging(string value);
    partial void OnGioiTinhChanged();
    partial void OnSoDienThoaiChanging(string value);
    partial void OnSoDienThoaiChanged();
    #endregion
		
		public NhanVien()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_NhanVien", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID_NhanVien
		{
			get
			{
				return this._ID_NhanVien;
			}
			set
			{
				if ((this._ID_NhanVien != value))
				{
					this.OnID_NhanVienChanging(value);
					this.SendPropertyChanging();
					this._ID_NhanVien = value;
					this.SendPropertyChanged("ID_NhanVien");
					this.OnID_NhanVienChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HoTen", DbType="NVarChar(255)")]
		public string HoTen
		{
			get
			{
				return this._HoTen;
			}
			set
			{
				if ((this._HoTen != value))
				{
					this.OnHoTenChanging(value);
					this.SendPropertyChanging();
					this._HoTen = value;
					this.SendPropertyChanged("HoTen");
					this.OnHoTenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgaySinh", DbType="Date")]
		public System.Nullable<System.DateTime> NgaySinh
		{
			get
			{
				return this._NgaySinh;
			}
			set
			{
				if ((this._NgaySinh != value))
				{
					this.OnNgaySinhChanging(value);
					this.SendPropertyChanging();
					this._NgaySinh = value;
					this.SendPropertyChanged("NgaySinh");
					this.OnNgaySinhChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GioiTinh", DbType="NVarChar(10)")]
		public string GioiTinh
		{
			get
			{
				return this._GioiTinh;
			}
			set
			{
				if ((this._GioiTinh != value))
				{
					this.OnGioiTinhChanging(value);
					this.SendPropertyChanging();
					this._GioiTinh = value;
					this.SendPropertyChanged("GioiTinh");
					this.OnGioiTinhChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SoDienThoai", DbType="NVarChar(20)")]
		public string SoDienThoai
		{
			get
			{
				return this._SoDienThoai;
			}
			set
			{
				if ((this._SoDienThoai != value))
				{
					this.OnSoDienThoaiChanging(value);
					this.SendPropertyChanging();
					this._SoDienThoai = value;
					this.SendPropertyChanged("SoDienThoai");
					this.OnSoDienThoaiChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Sushi")]
	public partial class Sushi : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID_Sushi;
		
		private string _TenSushi;
		
		private string _MoTa;
		
		private System.Nullable<decimal> _Gia;
		
		private string _Hinh;
		
		private EntitySet<ChiTietDonHang> _ChiTietDonHangs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnID_SushiChanging(int value);
    partial void OnID_SushiChanged();
    partial void OnTenSushiChanging(string value);
    partial void OnTenSushiChanged();
    partial void OnMoTaChanging(string value);
    partial void OnMoTaChanged();
    partial void OnGiaChanging(System.Nullable<decimal> value);
    partial void OnGiaChanged();
    partial void OnHinhChanging(string value);
    partial void OnHinhChanged();
    #endregion
		
		public Sushi()
		{
			this._ChiTietDonHangs = new EntitySet<ChiTietDonHang>(new Action<ChiTietDonHang>(this.attach_ChiTietDonHangs), new Action<ChiTietDonHang>(this.detach_ChiTietDonHangs));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_Sushi", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID_Sushi
		{
			get
			{
				return this._ID_Sushi;
			}
			set
			{
				if ((this._ID_Sushi != value))
				{
					this.OnID_SushiChanging(value);
					this.SendPropertyChanging();
					this._ID_Sushi = value;
					this.SendPropertyChanged("ID_Sushi");
					this.OnID_SushiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenSushi", DbType="VarChar(255)")]
		public string TenSushi
		{
			get
			{
				return this._TenSushi;
			}
			set
			{
				if ((this._TenSushi != value))
				{
					this.OnTenSushiChanging(value);
					this.SendPropertyChanging();
					this._TenSushi = value;
					this.SendPropertyChanged("TenSushi");
					this.OnTenSushiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MoTa", DbType="VarChar(255)")]
		public string MoTa
		{
			get
			{
				return this._MoTa;
			}
			set
			{
				if ((this._MoTa != value))
				{
					this.OnMoTaChanging(value);
					this.SendPropertyChanging();
					this._MoTa = value;
					this.SendPropertyChanged("MoTa");
					this.OnMoTaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Gia", DbType="Decimal(10,2)")]
		public System.Nullable<decimal> Gia
		{
			get
			{
				return this._Gia;
			}
			set
			{
				if ((this._Gia != value))
				{
					this.OnGiaChanging(value);
					this.SendPropertyChanging();
					this._Gia = value;
					this.SendPropertyChanged("Gia");
					this.OnGiaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Hinh", DbType="NChar(30)")]
		public string Hinh
		{
			get
			{
				return this._Hinh;
			}
			set
			{
				if ((this._Hinh != value))
				{
					this.OnHinhChanging(value);
					this.SendPropertyChanging();
					this._Hinh = value;
					this.SendPropertyChanged("Hinh");
					this.OnHinhChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Sushi_ChiTietDonHang", Storage="_ChiTietDonHangs", ThisKey="ID_Sushi", OtherKey="ID_Sushi")]
		public EntitySet<ChiTietDonHang> ChiTietDonHangs
		{
			get
			{
				return this._ChiTietDonHangs;
			}
			set
			{
				this._ChiTietDonHangs.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_ChiTietDonHangs(ChiTietDonHang entity)
		{
			this.SendPropertyChanging();
			entity.Sushi = this;
		}
		
		private void detach_ChiTietDonHangs(ChiTietDonHang entity)
		{
			this.SendPropertyChanging();
			entity.Sushi = null;
		}
	}
}
#pragma warning restore 1591
