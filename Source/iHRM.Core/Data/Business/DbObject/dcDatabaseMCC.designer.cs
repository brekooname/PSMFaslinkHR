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

namespace iHRM.Core.Business.DbObject
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="sHRM_QT")]
	public partial class dcDatabaseMCCDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InserttbMayChamCong(tbMayChamCong instance);
    partial void UpdatetbMayChamCong(tbMayChamCong instance);
    partial void DeletetbMayChamCong(tbMayChamCong instance);
    partial void InserttbNhanVien_Finger(tbNhanVien_Finger instance);
    partial void UpdatetbNhanVien_Finger(tbNhanVien_Finger instance);
    partial void DeletetbNhanVien_Finger(tbNhanVien_Finger instance);
    partial void InserttbNhanVien(tbNhanVien instance);
    partial void UpdatetbNhanVien(tbNhanVien instance);
    partial void DeletetbNhanVien(tbNhanVien instance);
    partial void InserttbCheckInOut(tbCheckInOut instance);
    partial void UpdatetbCheckInOut(tbCheckInOut instance);
    partial void DeletetbCheckInOut(tbCheckInOut instance);
    #endregion
		
		public dcDatabaseMCCDataContext() :
        base(global::iHRM.Core.Properties.Settings.Default.sHRM_QTConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public dcDatabaseMCCDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dcDatabaseMCCDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dcDatabaseMCCDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dcDatabaseMCCDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<tbMayChamCong> tbMayChamCongs
		{
			get
			{
				return this.GetTable<tbMayChamCong>();
			}
		}
		
		public System.Data.Linq.Table<tbNhanVien_Finger> tbNhanVien_Fingers
		{
			get
			{
				return this.GetTable<tbNhanVien_Finger>();
			}
		}
		
		public System.Data.Linq.Table<tbNhanVien> tbNhanViens
		{
			get
			{
				return this.GetTable<tbNhanVien>();
			}
		}
		
		public System.Data.Linq.Table<tbCheckInOut> tbCheckInOuts
		{
			get
			{
				return this.GetTable<tbCheckInOut>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tbMayChamCong")]
	public partial class tbMayChamCong : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _id;
		
		private int _soMay;
		
		private string _tenMay;
		
		private string _diaChiIP;
		
		private string _port;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(System.Guid value);
    partial void OnidChanged();
    partial void OnsoMayChanging(int value);
    partial void OnsoMayChanged();
    partial void OntenMayChanging(string value);
    partial void OntenMayChanged();
    partial void OndiaChiIPChanging(string value);
    partial void OndiaChiIPChanged();
    partial void OnportChanging(string value);
    partial void OnportChanged();
    #endregion
		
		public tbMayChamCong()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_soMay", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
		public int soMay
		{
			get
			{
				return this._soMay;
			}
			set
			{
				if ((this._soMay != value))
				{
					this.OnsoMayChanging(value);
					this.SendPropertyChanging();
					this._soMay = value;
					this.SendPropertyChanged("soMay");
					this.OnsoMayChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tenMay", DbType="NVarChar(100)")]
		public string tenMay
		{
			get
			{
				return this._tenMay;
			}
			set
			{
				if ((this._tenMay != value))
				{
					this.OntenMayChanging(value);
					this.SendPropertyChanging();
					this._tenMay = value;
					this.SendPropertyChanged("tenMay");
					this.OntenMayChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_diaChiIP", DbType="NVarChar(20)")]
		public string diaChiIP
		{
			get
			{
				return this._diaChiIP;
			}
			set
			{
				if ((this._diaChiIP != value))
				{
					this.OndiaChiIPChanging(value);
					this.SendPropertyChanging();
					this._diaChiIP = value;
					this.SendPropertyChanged("diaChiIP");
					this.OndiaChiIPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_port", DbType="VarChar(10)")]
		public string port
		{
			get
			{
				return this._port;
			}
			set
			{
				if ((this._port != value))
				{
					this.OnportChanging(value);
					this.SendPropertyChanging();
					this._port = value;
					this.SendPropertyChanged("port");
					this.OnportChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tbNhanVien_Finger")]
	public partial class tbNhanVien_Finger : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _maChamCong;
		
		private int _num_Finger;
		
		private string _str_Finger;
		
		private System.Data.Linq.Binary _byte_Finger;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnmaChamCongChanging(long value);
    partial void OnmaChamCongChanged();
    partial void Onnum_FingerChanging(int value);
    partial void Onnum_FingerChanged();
    partial void Onstr_FingerChanging(string value);
    partial void Onstr_FingerChanged();
    partial void Onbyte_FingerChanging(System.Data.Linq.Binary value);
    partial void Onbyte_FingerChanged();
    #endregion
		
		public tbNhanVien_Finger()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_maChamCong", DbType="BigInt NOT NULL", IsPrimaryKey=true)]
		public long maChamCong
		{
			get
			{
				return this._maChamCong;
			}
			set
			{
				if ((this._maChamCong != value))
				{
					this.OnmaChamCongChanging(value);
					this.SendPropertyChanging();
					this._maChamCong = value;
					this.SendPropertyChanged("maChamCong");
					this.OnmaChamCongChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_num_Finger", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int num_Finger
		{
			get
			{
				return this._num_Finger;
			}
			set
			{
				if ((this._num_Finger != value))
				{
					this.Onnum_FingerChanging(value);
					this.SendPropertyChanging();
					this._num_Finger = value;
					this.SendPropertyChanged("num_Finger");
					this.Onnum_FingerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_str_Finger", DbType="NVarChar(MAX)")]
		public string str_Finger
		{
			get
			{
				return this._str_Finger;
			}
			set
			{
				if ((this._str_Finger != value))
				{
					this.Onstr_FingerChanging(value);
					this.SendPropertyChanging();
					this._str_Finger = value;
					this.SendPropertyChanged("str_Finger");
					this.Onstr_FingerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_byte_Finger", DbType="Binary(8000)", CanBeNull=true, UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary byte_Finger
		{
			get
			{
				return this._byte_Finger;
			}
			set
			{
				if ((this._byte_Finger != value))
				{
					this.Onbyte_FingerChanging(value);
					this.SendPropertyChanging();
					this._byte_Finger = value;
					this.SendPropertyChanged("byte_Finger");
					this.Onbyte_FingerChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tbNhanVien")]
	public partial class tbNhanVien : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _maChamCong;
		
		private string _tenChamCong;
		
		private string _maThe;
		
		private string _vanTay;
		
		private string _maThesHRM;
		
		private string _loaiNhanVien;
		
		private string _trangThai;
		
		private string _maNV;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnmaChamCongChanging(long value);
    partial void OnmaChamCongChanged();
    partial void OntenChamCongChanging(string value);
    partial void OntenChamCongChanged();
    partial void OnmaTheChanging(string value);
    partial void OnmaTheChanged();
    partial void OnvanTayChanging(string value);
    partial void OnvanTayChanged();
    partial void OnmaThesHRMChanging(string value);
    partial void OnmaThesHRMChanged();
    partial void OnloaiNhanVienChanging(string value);
    partial void OnloaiNhanVienChanged();
    partial void OntrangThaiChanging(string value);
    partial void OntrangThaiChanged();
    partial void OnmaNVChanging(string value);
    partial void OnmaNVChanged();
    #endregion
		
		public tbNhanVien()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_maChamCong", DbType="BigInt NOT NULL", IsPrimaryKey=true)]
		public long maChamCong
		{
			get
			{
				return this._maChamCong;
			}
			set
			{
				if ((this._maChamCong != value))
				{
					this.OnmaChamCongChanging(value);
					this.SendPropertyChanging();
					this._maChamCong = value;
					this.SendPropertyChanged("maChamCong");
					this.OnmaChamCongChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tenChamCong", DbType="VarChar(30)")]
		public string tenChamCong
		{
			get
			{
				return this._tenChamCong;
			}
			set
			{
				if ((this._tenChamCong != value))
				{
					this.OntenChamCongChanging(value);
					this.SendPropertyChanging();
					this._tenChamCong = value;
					this.SendPropertyChanged("tenChamCong");
					this.OntenChamCongChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_maThe", DbType="VarChar(20)")]
		public string maThe
		{
			get
			{
				return this._maThe;
			}
			set
			{
				if ((this._maThe != value))
				{
					this.OnmaTheChanging(value);
					this.SendPropertyChanging();
					this._maThe = value;
					this.SendPropertyChanged("maThe");
					this.OnmaTheChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_vanTay", DbType="NVarChar(MAX)")]
		public string vanTay
		{
			get
			{
				return this._vanTay;
			}
			set
			{
				if ((this._vanTay != value))
				{
					this.OnvanTayChanging(value);
					this.SendPropertyChanging();
					this._vanTay = value;
					this.SendPropertyChanged("vanTay");
					this.OnvanTayChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_maThesHRM", DbType="VarChar(20)")]
		public string maThesHRM
		{
			get
			{
				return this._maThesHRM;
			}
			set
			{
				if ((this._maThesHRM != value))
				{
					this.OnmaThesHRMChanging(value);
					this.SendPropertyChanging();
					this._maThesHRM = value;
					this.SendPropertyChanged("maThesHRM");
					this.OnmaThesHRMChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_loaiNhanVien", DbType="NVarChar(20)")]
		public string loaiNhanVien
		{
			get
			{
				return this._loaiNhanVien;
			}
			set
			{
				if ((this._loaiNhanVien != value))
				{
					this.OnloaiNhanVienChanging(value);
					this.SendPropertyChanging();
					this._loaiNhanVien = value;
					this.SendPropertyChanged("loaiNhanVien");
					this.OnloaiNhanVienChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_trangThai", DbType="VarChar(10)")]
		public string trangThai
		{
			get
			{
				return this._trangThai;
			}
			set
			{
				if ((this._trangThai != value))
				{
					this.OntrangThaiChanging(value);
					this.SendPropertyChanging();
					this._trangThai = value;
					this.SendPropertyChanged("trangThai");
					this.OntrangThaiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_maNV", DbType="VarChar(20)")]
		public string maNV
		{
			get
			{
				return this._maNV;
			}
			set
			{
				if ((this._maNV != value))
				{
					this.OnmaNVChanging(value);
					this.SendPropertyChanging();
					this._maNV = value;
					this.SendPropertyChanged("maNV");
					this.OnmaNVChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tbCheckInOut")]
	public partial class tbCheckInOut : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _idx;
		
		private string _maChamCong;
		
		private System.Nullable<System.DateTime> _ngayQuet;
		
		private System.Nullable<System.DateTime> _tgQuet;
		
		private System.Nullable<System.DateTime> _tgMayClient;
		
		private System.Nullable<System.DateTime> _tgMayServer;
		
		private System.Nullable<int> _soMay;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidxChanging(int value);
    partial void OnidxChanged();
    partial void OnmaChamCongChanging(string value);
    partial void OnmaChamCongChanged();
    partial void OnngayQuetChanging(System.Nullable<System.DateTime> value);
    partial void OnngayQuetChanged();
    partial void OntgQuetChanging(System.Nullable<System.DateTime> value);
    partial void OntgQuetChanged();
    partial void OntgMayClientChanging(System.Nullable<System.DateTime> value);
    partial void OntgMayClientChanged();
    partial void OntgMayServerChanging(System.Nullable<System.DateTime> value);
    partial void OntgMayServerChanged();
    partial void OnsoMayChanging(System.Nullable<int> value);
    partial void OnsoMayChanged();
    #endregion
		
		public tbCheckInOut()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idx", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int idx
		{
			get
			{
				return this._idx;
			}
			set
			{
				if ((this._idx != value))
				{
					this.OnidxChanging(value);
					this.SendPropertyChanging();
					this._idx = value;
					this.SendPropertyChanged("idx");
					this.OnidxChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_maChamCong", DbType="VarChar(30)")]
		public string maChamCong
		{
			get
			{
				return this._maChamCong;
			}
			set
			{
				if ((this._maChamCong != value))
				{
					this.OnmaChamCongChanging(value);
					this.SendPropertyChanging();
					this._maChamCong = value;
					this.SendPropertyChanged("maChamCong");
					this.OnmaChamCongChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ngayQuet", DbType="DateTime")]
		public System.Nullable<System.DateTime> ngayQuet
		{
			get
			{
				return this._ngayQuet;
			}
			set
			{
				if ((this._ngayQuet != value))
				{
					this.OnngayQuetChanging(value);
					this.SendPropertyChanging();
					this._ngayQuet = value;
					this.SendPropertyChanged("ngayQuet");
					this.OnngayQuetChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tgQuet", DbType="DateTime")]
		public System.Nullable<System.DateTime> tgQuet
		{
			get
			{
				return this._tgQuet;
			}
			set
			{
				if ((this._tgQuet != value))
				{
					this.OntgQuetChanging(value);
					this.SendPropertyChanging();
					this._tgQuet = value;
					this.SendPropertyChanged("tgQuet");
					this.OntgQuetChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tgMayClient", DbType="DateTime")]
		public System.Nullable<System.DateTime> tgMayClient
		{
			get
			{
				return this._tgMayClient;
			}
			set
			{
				if ((this._tgMayClient != value))
				{
					this.OntgMayClientChanging(value);
					this.SendPropertyChanging();
					this._tgMayClient = value;
					this.SendPropertyChanged("tgMayClient");
					this.OntgMayClientChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tgMayServer", DbType="DateTime")]
		public System.Nullable<System.DateTime> tgMayServer
		{
			get
			{
				return this._tgMayServer;
			}
			set
			{
				if ((this._tgMayServer != value))
				{
					this.OntgMayServerChanging(value);
					this.SendPropertyChanging();
					this._tgMayServer = value;
					this.SendPropertyChanged("tgMayServer");
					this.OntgMayServerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_soMay", DbType="Int")]
		public System.Nullable<int> soMay
		{
			get
			{
				return this._soMay;
			}
			set
			{
				if ((this._soMay != value))
				{
					this.OnsoMayChanging(value);
					this.SendPropertyChanging();
					this._soMay = value;
					this.SendPropertyChanged("soMay");
					this.OnsoMayChanged();
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
}
#pragma warning restore 1591
