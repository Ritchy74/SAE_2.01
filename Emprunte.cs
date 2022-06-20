using System;

namespace diagramme_classes {
	public class Emprunte : CRUD  {
		public int IdEmploye { get; set; }
		public int IdDate { get; set; }
		public int IdVehicule { get; set; }
		public char Mission { get; set; }
		public DateTime Date { get; set; }

		public Emprunte() {
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

		private Vehicule vehicule;
		private Employe[] employes;

	}

}
