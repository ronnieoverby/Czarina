### Goals

- Easy, convenient generation of realistic data
- Rich, composable, accessible library of sample data
	- Political data (countries, states, cities, currencies, etc.)
    - Names (people, businesses, streets, etc.)
	- Parts of speech

---

### Features
 - Convenient POCO generation
 - Convenient ADO.NET generation w/ relational data
 - Realistic data generation
	- Sample biasing
	- Language generation engines	
 - Rich library of random extension methods
 - No dependencies
 - Extensible sample library (text file based)

---

### Steps

 - Gather Samples (ongoing)
 - Create api for selecting samples
 - Create extensions to Random for generation of other .net types
 - Create API for specifying generation strategy of POCOs
	- specify samples
	- biasing
 - Create API for boxing up common generators
	- Email address generator (uses name samples)

#### Sample Selection
 - Samples.Cities
 - Samples.Cities.NC
 - Samples.States.USA
 - Samples.States.Mexico
 - Samples.Provinces.Canada
 - Samples.StreetNames
 - Samples.Companies
 - Samples.Colors
 - Samples.BusinessSectors
 - Samples.Names.Chinese
 - Samples.Names.First.Male
 - Samples.Names.First.Female
 - Samples.Names.Last
 - Samples.Names.First
 - Samples.First.Names