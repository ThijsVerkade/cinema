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

namespace Cinema_V2
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="dbCinema")]
	public partial class DbCinemaDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertHall(Hall instance);
    partial void UpdateHall(Hall instance);
    partial void DeleteHall(Hall instance);
    partial void InsertMovie(Movie instance);
    partial void UpdateMovie(Movie instance);
    partial void DeleteMovie(Movie instance);
    partial void InsertReservation(Reservation instance);
    partial void UpdateReservation(Reservation instance);
    partial void DeleteReservation(Reservation instance);
    partial void InsertSession(Session instance);
    partial void UpdateSession(Session instance);
    partial void DeleteSession(Session instance);
    #endregion
		
		public DbCinemaDataContext() : 
				base(global::Cinema_V2.Properties.Settings.Default.dbCinemaConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DbCinemaDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DbCinemaDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DbCinemaDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DbCinemaDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Hall> Halls
		{
			get
			{
				return this.GetTable<Hall>();
			}
		}
		
		public System.Data.Linq.Table<Movie> Movies
		{
			get
			{
				return this.GetTable<Movie>();
			}
		}
		
		public System.Data.Linq.Table<Reservation> Reservations
		{
			get
			{
				return this.GetTable<Reservation>();
			}
		}
		
		public System.Data.Linq.Table<Session> Sessions
		{
			get
			{
				return this.GetTable<Session>();
			}
		}
		
		public System.Data.Linq.Table<User> Users
		{
			get
			{
				return this.GetTable<User>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Hall")]
	public partial class Hall : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _hId;
		
		private System.Nullable<int> _hAmoutSeats;
		
		private EntitySet<Session> _Sessions;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnhIdChanging(int value);
    partial void OnhIdChanged();
    partial void OnhAmoutSeatsChanging(System.Nullable<int> value);
    partial void OnhAmoutSeatsChanged();
    #endregion
		
		public Hall()
		{
			this._Sessions = new EntitySet<Session>(new Action<Session>(this.attach_Sessions), new Action<Session>(this.detach_Sessions));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_hId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int hId
		{
			get
			{
				return this._hId;
			}
			set
			{
				if ((this._hId != value))
				{
					this.OnhIdChanging(value);
					this.SendPropertyChanging();
					this._hId = value;
					this.SendPropertyChanged("hId");
					this.OnhIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_hAmoutSeats", DbType="Int")]
		public System.Nullable<int> hAmoutSeats
		{
			get
			{
				return this._hAmoutSeats;
			}
			set
			{
				if ((this._hAmoutSeats != value))
				{
					this.OnhAmoutSeatsChanging(value);
					this.SendPropertyChanging();
					this._hAmoutSeats = value;
					this.SendPropertyChanged("hAmoutSeats");
					this.OnhAmoutSeatsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Hall_Session", Storage="_Sessions", ThisKey="hId", OtherKey="hId")]
		public EntitySet<Session> Sessions
		{
			get
			{
				return this._Sessions;
			}
			set
			{
				this._Sessions.Assign(value);
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
		
		private void attach_Sessions(Session entity)
		{
			this.SendPropertyChanging();
			entity.Hall = this;
		}
		
		private void detach_Sessions(Session entity)
		{
			this.SendPropertyChanging();
			entity.Hall = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Movie")]
	public partial class Movie : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _mId;
		
		private int _mMinutes;
		
		private string _mTitle;
		
		private string _mGenre;
		
		private System.DateTime _mDate;
		
		private string _mDescription;
		
		private string _mPictureUrl;
		
		private string _mVideoUrl;
		
		private EntitySet<Session> _Sessions;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnmIdChanging(int value);
    partial void OnmIdChanged();
    partial void OnmMinutesChanging(int value);
    partial void OnmMinutesChanged();
    partial void OnmTitleChanging(string value);
    partial void OnmTitleChanged();
    partial void OnmGenreChanging(string value);
    partial void OnmGenreChanged();
    partial void OnmDateChanging(System.DateTime value);
    partial void OnmDateChanged();
    partial void OnmDescriptionChanging(string value);
    partial void OnmDescriptionChanged();
    partial void OnmPictureUrlChanging(string value);
    partial void OnmPictureUrlChanged();
    partial void OnmVideoUrlChanging(string value);
    partial void OnmVideoUrlChanged();
    #endregion
		
		public Movie()
		{
			this._Sessions = new EntitySet<Session>(new Action<Session>(this.attach_Sessions), new Action<Session>(this.detach_Sessions));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_mId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int mId
		{
			get
			{
				return this._mId;
			}
			set
			{
				if ((this._mId != value))
				{
					this.OnmIdChanging(value);
					this.SendPropertyChanging();
					this._mId = value;
					this.SendPropertyChanged("mId");
					this.OnmIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_mMinutes", DbType="Int NOT NULL")]
		public int mMinutes
		{
			get
			{
				return this._mMinutes;
			}
			set
			{
				if ((this._mMinutes != value))
				{
					this.OnmMinutesChanging(value);
					this.SendPropertyChanging();
					this._mMinutes = value;
					this.SendPropertyChanged("mMinutes");
					this.OnmMinutesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_mTitle", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string mTitle
		{
			get
			{
				return this._mTitle;
			}
			set
			{
				if ((this._mTitle != value))
				{
					this.OnmTitleChanging(value);
					this.SendPropertyChanging();
					this._mTitle = value;
					this.SendPropertyChanged("mTitle");
					this.OnmTitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_mGenre", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string mGenre
		{
			get
			{
				return this._mGenre;
			}
			set
			{
				if ((this._mGenre != value))
				{
					this.OnmGenreChanging(value);
					this.SendPropertyChanging();
					this._mGenre = value;
					this.SendPropertyChanged("mGenre");
					this.OnmGenreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_mDate", DbType="Date NOT NULL")]
		public System.DateTime mDate
		{
			get
			{
				return this._mDate;
			}
			set
			{
				if ((this._mDate != value))
				{
					this.OnmDateChanging(value);
					this.SendPropertyChanging();
					this._mDate = value;
					this.SendPropertyChanged("mDate");
					this.OnmDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_mDescription", DbType="Text NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string mDescription
		{
			get
			{
				return this._mDescription;
			}
			set
			{
				if ((this._mDescription != value))
				{
					this.OnmDescriptionChanging(value);
					this.SendPropertyChanging();
					this._mDescription = value;
					this.SendPropertyChanged("mDescription");
					this.OnmDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_mPictureUrl", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string mPictureUrl
		{
			get
			{
				return this._mPictureUrl;
			}
			set
			{
				if ((this._mPictureUrl != value))
				{
					this.OnmPictureUrlChanging(value);
					this.SendPropertyChanging();
					this._mPictureUrl = value;
					this.SendPropertyChanged("mPictureUrl");
					this.OnmPictureUrlChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_mVideoUrl", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string mVideoUrl
		{
			get
			{
				return this._mVideoUrl;
			}
			set
			{
				if ((this._mVideoUrl != value))
				{
					this.OnmVideoUrlChanging(value);
					this.SendPropertyChanging();
					this._mVideoUrl = value;
					this.SendPropertyChanged("mVideoUrl");
					this.OnmVideoUrlChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Movie_Session", Storage="_Sessions", ThisKey="mId", OtherKey="mId")]
		public EntitySet<Session> Sessions
		{
			get
			{
				return this._Sessions;
			}
			set
			{
				this._Sessions.Assign(value);
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
		
		private void attach_Sessions(Session entity)
		{
			this.SendPropertyChanging();
			entity.Movie = this;
		}
		
		private void detach_Sessions(Session entity)
		{
			this.SendPropertyChanging();
			entity.Movie = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Reservation")]
	public partial class Reservation : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _rId;
		
		private int _rSeat;
		
		private int _sId;
		
		private System.DateTime _rDate;
		
		private EntityRef<Session> _Session;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnrIdChanging(int value);
    partial void OnrIdChanged();
    partial void OnrSeatChanging(int value);
    partial void OnrSeatChanged();
    partial void OnsIdChanging(int value);
    partial void OnsIdChanged();
    partial void OnrDateChanging(System.DateTime value);
    partial void OnrDateChanged();
    #endregion
		
		public Reservation()
		{
			this._Session = default(EntityRef<Session>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_rId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int rId
		{
			get
			{
				return this._rId;
			}
			set
			{
				if ((this._rId != value))
				{
					if (this._Session.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnrIdChanging(value);
					this.SendPropertyChanging();
					this._rId = value;
					this.SendPropertyChanged("rId");
					this.OnrIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_rSeat", DbType="Int NOT NULL")]
		public int rSeat
		{
			get
			{
				return this._rSeat;
			}
			set
			{
				if ((this._rSeat != value))
				{
					this.OnrSeatChanging(value);
					this.SendPropertyChanging();
					this._rSeat = value;
					this.SendPropertyChanged("rSeat");
					this.OnrSeatChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sId", DbType="Int NOT NULL")]
		public int sId
		{
			get
			{
				return this._sId;
			}
			set
			{
				if ((this._sId != value))
				{
					this.OnsIdChanging(value);
					this.SendPropertyChanging();
					this._sId = value;
					this.SendPropertyChanged("sId");
					this.OnsIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_rDate", DbType="Date NOT NULL")]
		public System.DateTime rDate
		{
			get
			{
				return this._rDate;
			}
			set
			{
				if ((this._rDate != value))
				{
					this.OnrDateChanging(value);
					this.SendPropertyChanging();
					this._rDate = value;
					this.SendPropertyChanged("rDate");
					this.OnrDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Session_Reservation", Storage="_Session", ThisKey="rId", OtherKey="sId", IsForeignKey=true)]
		public Session Session
		{
			get
			{
				return this._Session.Entity;
			}
			set
			{
				Session previousValue = this._Session.Entity;
				if (((previousValue != value) 
							|| (this._Session.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Session.Entity = null;
						previousValue.Reservation = null;
					}
					this._Session.Entity = value;
					if ((value != null))
					{
						value.Reservation = this;
						this._rId = value.sId;
					}
					else
					{
						this._rId = default(int);
					}
					this.SendPropertyChanged("Session");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Session")]
	public partial class Session : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _sId;
		
		private int _hId;
		
		private int _mId;
		
		private System.DateTime _sDate;
		
		private EntityRef<Reservation> _Reservation;
		
		private EntityRef<Hall> _Hall;
		
		private EntityRef<Movie> _Movie;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnsIdChanging(int value);
    partial void OnsIdChanged();
    partial void OnhIdChanging(int value);
    partial void OnhIdChanged();
    partial void OnmIdChanging(int value);
    partial void OnmIdChanged();
    partial void OnsDateChanging(System.DateTime value);
    partial void OnsDateChanged();
    #endregion
		
		public Session()
		{
			this._Reservation = default(EntityRef<Reservation>);
			this._Hall = default(EntityRef<Hall>);
			this._Movie = default(EntityRef<Movie>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int sId
		{
			get
			{
				return this._sId;
			}
			set
			{
				if ((this._sId != value))
				{
					this.OnsIdChanging(value);
					this.SendPropertyChanging();
					this._sId = value;
					this.SendPropertyChanged("sId");
					this.OnsIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_hId", DbType="Int NOT NULL")]
		public int hId
		{
			get
			{
				return this._hId;
			}
			set
			{
				if ((this._hId != value))
				{
					if (this._Hall.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnhIdChanging(value);
					this.SendPropertyChanging();
					this._hId = value;
					this.SendPropertyChanged("hId");
					this.OnhIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_mId", DbType="Int NOT NULL")]
		public int mId
		{
			get
			{
				return this._mId;
			}
			set
			{
				if ((this._mId != value))
				{
					if (this._Movie.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnmIdChanging(value);
					this.SendPropertyChanging();
					this._mId = value;
					this.SendPropertyChanged("mId");
					this.OnmIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sDate", DbType="Date NOT NULL")]
		public System.DateTime sDate
		{
			get
			{
				return this._sDate;
			}
			set
			{
				if ((this._sDate != value))
				{
					this.OnsDateChanging(value);
					this.SendPropertyChanging();
					this._sDate = value;
					this.SendPropertyChanged("sDate");
					this.OnsDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Session_Reservation", Storage="_Reservation", ThisKey="sId", OtherKey="rId", IsUnique=true, IsForeignKey=false)]
		public Reservation Reservation
		{
			get
			{
				return this._Reservation.Entity;
			}
			set
			{
				Reservation previousValue = this._Reservation.Entity;
				if (((previousValue != value) 
							|| (this._Reservation.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Reservation.Entity = null;
						previousValue.Session = null;
					}
					this._Reservation.Entity = value;
					if ((value != null))
					{
						value.Session = this;
					}
					this.SendPropertyChanged("Reservation");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Hall_Session", Storage="_Hall", ThisKey="hId", OtherKey="hId", IsForeignKey=true)]
		public Hall Hall
		{
			get
			{
				return this._Hall.Entity;
			}
			set
			{
				Hall previousValue = this._Hall.Entity;
				if (((previousValue != value) 
							|| (this._Hall.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Hall.Entity = null;
						previousValue.Sessions.Remove(this);
					}
					this._Hall.Entity = value;
					if ((value != null))
					{
						value.Sessions.Add(this);
						this._hId = value.hId;
					}
					else
					{
						this._hId = default(int);
					}
					this.SendPropertyChanged("Hall");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Movie_Session", Storage="_Movie", ThisKey="mId", OtherKey="mId", IsForeignKey=true)]
		public Movie Movie
		{
			get
			{
				return this._Movie.Entity;
			}
			set
			{
				Movie previousValue = this._Movie.Entity;
				if (((previousValue != value) 
							|| (this._Movie.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Movie.Entity = null;
						previousValue.Sessions.Remove(this);
					}
					this._Movie.Entity = value;
					if ((value != null))
					{
						value.Sessions.Add(this);
						this._mId = value.mId;
					}
					else
					{
						this._mId = default(int);
					}
					this.SendPropertyChanged("Movie");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Users")]
	public partial class User
	{
		
		private System.Nullable<int> _UserID;
		
		private string _Username;
		
		private string _Password;
		
		public User()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", DbType="Int")]
		public System.Nullable<int> UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this._UserID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="VarChar(50)")]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				if ((this._Username != value))
				{
					this._Username = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="VarChar(50)")]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this._Password = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
