using System;
using System.Collections.Generic;

namespace diagramme_classes {
	public class Vehicule : CRUD  {
		public int IdVehicule { get; set; }
		public char LibelleVehicule { get; set; }

		public Vehicule() {
			throw new System.NotImplementedException("Not implemented");
		}
		public void Delete() {
			throw new System.NotImplementedException("Not implemented");
		}
		public void Update() {
			throw new System.NotImplementedException("Not implemented");
		}
		public void Read() {
			throw new System.NotImplementedException("Not implemented");
		}
		public void Create() {
			throw new System.NotImplementedException("Not implemented");
		}

		private CategorieVehicule categorieVehicule;

		private List<Emprunte> empruntes;

	}

}
