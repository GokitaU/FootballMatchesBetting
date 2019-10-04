﻿//---------------------------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated by T4Model template for T4 (https://github.com/linq2db/linq2db).
//    Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//---------------------------------------------------------------------------------------------------

#pragma warning disable 1591

using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

namespace FootballMatchesBetting.Database
{
	/// <summary>
	/// Database       : FootballMatchesBetting
	/// Data Source    : (LocalDb)\MSSQLLocalDB
	/// Server Version : 13.00.4001
	/// </summary>
	public partial class FootballMatchesDb : LinqToDB.Data.DataConnection
	{
		public ITable<Games>       Games       { get { return this.GetTable<Games>(); } }
		public ITable<Leagues>     Leagues     { get { return this.GetTable<Leagues>(); } }
		public ITable<Points>      Points      { get { return this.GetTable<Points>(); } }
		public ITable<Predictions> Predictions { get { return this.GetTable<Predictions>(); } }
		public ITable<Roles>       Roles       { get { return this.GetTable<Roles>(); } }
		public ITable<Teams>       Teams       { get { return this.GetTable<Teams>(); } }
		public ITable<Users>       Users       { get { return this.GetTable<Users>(); } }

		public FootballMatchesDb()
		{
			InitDataContext();
			InitMappingSchema();
		}

		public FootballMatchesDb(string configuration)
			: base(configuration)
		{
			InitDataContext();
			InitMappingSchema();
		}

		partial void InitDataContext  ();
		partial void InitMappingSchema();
	}

	[Table(Schema="dbo", Name="Games")]
	public partial class Games
	{
		[PrimaryKey, NotNull    ] public Guid     GameId        { get; set; } // uniqueidentifier
		[Column,     NotNull    ] public Guid     HomeTeamId    { get; set; } // uniqueidentifier
		[Column,     NotNull    ] public Guid     AwayTeamId    { get; set; } // uniqueidentifier
		[Column,        Nullable] public int?     HomeTeamGoals { get; set; } // int
		[Column,        Nullable] public int?     AwayTeamGoals { get; set; } // int
		[Column,     NotNull    ] public DateTime StartDateTime { get; set; } // datetime
		[Column,     NotNull    ] public int      Gameweek      { get; set; } // int
		[Column,     NotNull    ] public int      LeagueId      { get; set; } // int

		#region Associations

		/// <summary>
		/// FK_Games_Teams_Away
		/// </summary>
		[Association(ThisKey="AwayTeamId", OtherKey="TeamId", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_Games_Teams_Away", BackReferenceName="GamesAways")]
		public Teams AwayTeam { get; set; }

		/// <summary>
		/// FK_Games_Teams_Home
		/// </summary>
		[Association(ThisKey="HomeTeamId", OtherKey="TeamId", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_Games_Teams_Home", BackReferenceName="GamesHomes")]
		public Teams HomeTeam { get; set; }

		/// <summary>
		/// FK_Games_Leagues
		/// </summary>
		[Association(ThisKey="LeagueId", OtherKey="LeagueId", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_Games_Leagues", BackReferenceName="Games")]
		public Leagues League { get; set; }

		/// <summary>
		/// FK_Predictions_Games_BackReference
		/// </summary>
		[Association(ThisKey="GameId", OtherKey="GameId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<Predictions> Predictions { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="Leagues")]
	public partial class Leagues
	{
		[PrimaryKey, NotNull] public int    LeagueId   { get; set; } // int
		[Column,     NotNull] public string LeagueName { get; set; } // nvarchar(100)

		#region Associations

		/// <summary>
		/// FK_Games_Leagues_BackReference
		/// </summary>
		[Association(ThisKey="LeagueId", OtherKey="LeagueId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<Games> Games { get; set; }

		/// <summary>
		/// FK_Points_Leagues_BackReference
		/// </summary>
		[Association(ThisKey="LeagueId", OtherKey="LeagueId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<Points> Points { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="Points")]
	public partial class Points
	{
		[Column(),         PrimaryKey(1), NotNull] public Guid UserId               { get; set; } // uniqueidentifier
		[Column(),         PrimaryKey(2), NotNull] public int  LeagueId             { get; set; } // int
		[Column("Points"),                NotNull] public int  Points_Column        { get; set; } // int
		[Column(),                        NotNull] public int  GamesPredicted       { get; set; } // int
		[Column(),                        NotNull] public int  MatchingResults      { get; set; } // int
		[Column(),                        NotNull] public int  MatchingExactResults { get; set; } // int

		#region Associations

		/// <summary>
		/// FK_Points_Leagues
		/// </summary>
		[Association(ThisKey="LeagueId", OtherKey="LeagueId", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_Points_Leagues", BackReferenceName="Points")]
		public Leagues League { get; set; }

		/// <summary>
		/// FK_Points_Users
		/// </summary>
		[Association(ThisKey="UserId", OtherKey="UserId", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_Points_Users", BackReferenceName="Points")]
		public Users User { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="Predictions")]
	public partial class Predictions
	{
		[PrimaryKey(1), NotNull    ] public Guid UserId        { get; set; } // uniqueidentifier
		[PrimaryKey(2), NotNull    ] public Guid GameId        { get; set; } // uniqueidentifier
		[Column,           Nullable] public int? HomeTeamGoals { get; set; } // int
		[Column,           Nullable] public int? AwayTeamGoals { get; set; } // int

		#region Associations

		/// <summary>
		/// FK_Predictions_Games
		/// </summary>
		[Association(ThisKey="GameId", OtherKey="GameId", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_Predictions_Games", BackReferenceName="Predictions")]
		public Games Game { get; set; }

		/// <summary>
		/// FK_Predictions_Users
		/// </summary>
		[Association(ThisKey="UserId", OtherKey="UserId", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_Predictions_Users", BackReferenceName="Predictions")]
		public Users User { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="Roles")]
	public partial class Roles
	{
		[PrimaryKey, NotNull] public int    RoleId   { get; set; } // int
		[Column,     NotNull] public string RoleName { get; set; } // nvarchar(50)

		#region Associations

		/// <summary>
		/// FK_Users_Roles_BackReference
		/// </summary>
		[Association(ThisKey="RoleId", OtherKey="RoleId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<Users> Users { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="Teams")]
	public partial class Teams
	{
		[PrimaryKey, NotNull] public Guid   TeamId   { get; set; } // uniqueidentifier
		[Column,     NotNull] public string TeamName { get; set; } // nvarchar(50)

		#region Associations

		/// <summary>
		/// FK_Games_Teams_Away_BackReference
		/// </summary>
		[Association(ThisKey="TeamId", OtherKey="AwayTeamId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<Games> GamesAways { get; set; }

		/// <summary>
		/// FK_Games_Teams_Home_BackReference
		/// </summary>
		[Association(ThisKey="TeamId", OtherKey="HomeTeamId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<Games> GamesHomes { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="Users")]
	public partial class Users
	{
		[PrimaryKey, NotNull] public Guid   UserId   { get; set; } // uniqueidentifier
		[Column,     NotNull] public string Login    { get; set; } // nvarchar(50)
		[Column,     NotNull] public string Password { get; set; } // nvarchar(50)
		[Column,     NotNull] public int    RoleId   { get; set; } // int

		#region Associations

		/// <summary>
		/// FK_Points_Users_BackReference
		/// </summary>
		[Association(ThisKey="UserId", OtherKey="UserId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<Points> Points { get; set; }

		/// <summary>
		/// FK_Predictions_Users_BackReference
		/// </summary>
		[Association(ThisKey="UserId", OtherKey="UserId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<Predictions> Predictions { get; set; }

		/// <summary>
		/// FK_Users_Roles
		/// </summary>
		[Association(ThisKey="RoleId", OtherKey="RoleId", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_Users_Roles", BackReferenceName="Users")]
		public Roles Role { get; set; }

		#endregion
	}

	public static partial class TableExtensions
	{
		public static Games Find(this ITable<Games> table, Guid GameId)
		{
			return table.FirstOrDefault(t =>
				t.GameId == GameId);
		}

		public static Leagues Find(this ITable<Leagues> table, int LeagueId)
		{
			return table.FirstOrDefault(t =>
				t.LeagueId == LeagueId);
		}

		public static Points Find(this ITable<Points> table, Guid UserId, int LeagueId)
		{
			return table.FirstOrDefault(t =>
				t.UserId   == UserId &&
				t.LeagueId == LeagueId);
		}

		public static Predictions Find(this ITable<Predictions> table, Guid UserId, Guid GameId)
		{
			return table.FirstOrDefault(t =>
				t.UserId == UserId &&
				t.GameId == GameId);
		}

		public static Roles Find(this ITable<Roles> table, int RoleId)
		{
			return table.FirstOrDefault(t =>
				t.RoleId == RoleId);
		}

		public static Teams Find(this ITable<Teams> table, Guid TeamId)
		{
			return table.FirstOrDefault(t =>
				t.TeamId == TeamId);
		}

		public static Users Find(this ITable<Users> table, Guid UserId)
		{
			return table.FirstOrDefault(t =>
				t.UserId == UserId);
		}
	}
}

#pragma warning restore 1591
