using System;
using System.Collections.Generic;
using Mono.Data.Sqlite;




namespace ProjektProgramsko
{
	public static class BPCasopis
	{
		public static void Spremi(Casopis k)
		{
			BP.otvoriKonekciju();

			SqliteCommand command = BP.komanda();
			command.CommandText = @"create table if not exist Casopis (

			id integer primary key autoincrement,
			naziv string,
			tagovi string)";

		}


		public static List<Casopis> DohvatiSve()
		{
			List<Casopis> listaCasopisa = new List<Casopis>();

			BP.otvoriKonekciju();

			SqliteCommand command = BP.komanda();

			command.CommandText = "Select * from casopis, sadrzaj where casopis.id_sadrzaj = sadrzaj.id";

			SqliteDataReader reader = command.ExecuteReader();

			while (reader.Read())
			{
				Casopis k = new Casopis();

				k.Id = (int)(Int64)reader["id"];
				k.Naziv = (string)reader["naziv"];
				k.Tagovi = (string)reader["tagovi"];

				listaCasopisa.Add(k);
			}

			reader.Dispose();
			command.Dispose();

			return listaCasopisa;
		}
	}
}

