using System.Text.RegularExpressions;

public class Container {
	private ContainerName name;
	public ContainerName Name { 
		get { return name; } 
	} 
	private ContainerTemperature temperature;
	public ContainerTemperature Temperature { 
		get { return temperature; }
	}
	private ContainerDestination destination;
	public ContainerDestination Destination {
		get { return destination; }
	}

	public Container(ContainerName n) {
		name = n;
		// Determine Temperature/Destination
		if(name == ContainerName.HotCupForHere) {
			temperature = ContainerTemperature.Hot;
			destination = ContainerDestination.ForHere;
		}
		else if(name == ContainerName.HotCupToGo) {
			temperature = ContainerTemperature.Hot;
			destination = ContainerDestination.ToGo;
		}
		else if(name == ContainerName.ColdCupForHere) {
			temperature = ContainerTemperature.Cold;
			destination = ContainerDestination.ForHere;
		}
		else if(name == ContainerName.ColdCupToGo) {
			temperature = ContainerTemperature.Cold;
			destination = ContainerDestination.ToGo;
		}
	}

	public string GetNameText() {
		return SpaceCamelCase(name.ToString());
	}

	public string GetTemperatureText() {
		return SpaceCamelCase(temperature.ToString());
	}

	public string GetDestinationText() {
		return SpaceCamelCase(destination.ToString());
	}

	private string SpaceCamelCase(string input) {
		return Regex.Replace(input, "(\\B[A-Z])", " $1");
	}
}

public enum ContainerName {
	HotCupForHere, HotCupToGo, 
	ColdCupForHere, ColdCupToGo
}

public enum ContainerTemperature {
	Hot,
	Cold
}

public enum ContainerDestination {
	ForHere,
	ToGo
}
