using System.Text.RegularExpressions;

public class Container {
	public ContainerName Name; 
	public ContainerTemperature Temperature;
	public ContainerDestination Destination;

	public Container(ContainerName name) {
		Name = name;
		// Determine Temperature/Destination
		if(name == ContainerName.HotCupForHere) {
			Temperature = ContainerTemperature.Hot;
			Destination = ContainerDestination.ForHere;
		}
		else if(name == ContainerName.HotCupToGo) {
			Temperature = ContainerTemperature.Hot;
			Destination = ContainerDestination.ToGo;
		}
		else if(name == ContainerName.ColdCupForHere) {
			Temperature = ContainerTemperature.Cold;
			Destination = ContainerDestination.ForHere;
		}
		else if(name == ContainerName.ColdCupToGo) {
			Temperature = ContainerTemperature.Cold;
			Destination = ContainerDestination.ToGo;
		}
	}

	public string GetNameText() {
		return SpaceCamelCase(Name.ToString());
	}

	public string GetTemperatureText() {
		return SpaceCamelCase(Temperature.ToString());
	}

	public string GetDestinationText() {
		return SpaceCamelCase(Destination.ToString());
	}

	private string SpaceCamelCase(string input) {
		return Regex.Replace(input, "(\\B[A-Z])", " $1");
	}
}

public enum ContainerName {
	HotCupForHere, HotCupToGo, ColdCupForHere, ColdCupToGo
}

public enum ContainerTemperature {
	Hot,
	Cold
}

public enum ContainerDestination {
	ForHere,
	ToGo
}
