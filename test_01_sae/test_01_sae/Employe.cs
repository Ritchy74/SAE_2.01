using System;
using System.Collections.Generic;

namespace diagramme_classes {
	public class Employe : CRUD  {
		public int IdEmploye { get; set; }
		public char Nom { get; set; }
		public char Prenom { get; set; }
		public char TelEmploye { get; set; }
		public char Mail { get; set; }

		public Employe() {
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

		private List<Emprunte> empruntes;

	}

}
