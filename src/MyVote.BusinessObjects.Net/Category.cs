﻿using Csla;
using MyVote.BusinessObjects.Contracts;
using MyVote.BusinessObjects.Core;

#if !NETFX_CORE && !WINDOWS_PHONE
using MyVote.Repository;
#endif

namespace MyVote.BusinessObjects
{
#if (!NETFX_CORE && !WINDOWS_PHONE) || ANDROID
	[System.Serializable]
#else
	[Csla.Serialization.Serializable]
#endif
	internal sealed class Category
		: ReadOnlyBaseCore<Category>, ICategory
	{
#if !NETFX_CORE && !WINDOWS_PHONE
		private void Child_Fetch(MVCategory criteria)
		{
			this.ID = criteria.CategoryID;
			this.Name = criteria.CategoryName;
		}
#endif

		public static PropertyInfo<int> IDProperty =
			Category.RegisterProperty<int>(_ => _.ID);
		public int ID
		{
			get { return this.ReadProperty(Category.IDProperty); }
			private set { this.LoadProperty(Category.IDProperty, value); }
		}

		public static PropertyInfo<string> NameProperty =
			Category.RegisterProperty<string>(_ => _.Name);
		public string Name
		{
			get { return this.ReadProperty(Category.NameProperty); }
			private set { this.LoadProperty(Category.NameProperty, value); }
		}
	}
}
