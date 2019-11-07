﻿using System.Collections.Generic;
using Fluky.Types;

namespace Fluky
{
  public partial class Data
  {
    private IEnumerable<FirstName> _firstNames;

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<FirstName> FirstNames
    {
      get
      {
        if (_firstNames != null)
          return _firstNames;

        // Males
        var names = new List<FirstName>
        {
          new FirstName("James",GenderType.Male),
          new FirstName("John",GenderType.Male),
          new FirstName("Robert",GenderType.Male),
          new FirstName("Michael",GenderType.Male),
          new FirstName("William",GenderType.Male),
          new FirstName("David",GenderType.Male),
          new FirstName("Richard",GenderType.Male),
          new FirstName("Joseph",GenderType.Male),
          new FirstName("Charles",GenderType.Male),
          new FirstName("Thomas",GenderType.Male),
          new FirstName("Christopher",GenderType.Male),
          new FirstName("Daniel",GenderType.Male),
          new FirstName("Matthew",GenderType.Male),
          new FirstName("George",GenderType.Male),
          new FirstName("Donald",GenderType.Male),
          new FirstName("Anthony",GenderType.Male),
          new FirstName("Paul",GenderType.Male),
          new FirstName("Mark",GenderType.Male),
          new FirstName("Edward",GenderType.Male),
          new FirstName("Steven",GenderType.Male),
          new FirstName("Kenneth",GenderType.Male),
          new FirstName("Andrew",GenderType.Male),
          new FirstName("Brian",GenderType.Male),
          new FirstName("Joshua",GenderType.Male),
          new FirstName("Kevin",GenderType.Male),
          new FirstName("Ronald",GenderType.Male),
          new FirstName("Timothy",GenderType.Male),
          new FirstName("Jason",GenderType.Male),
          new FirstName("Jeffrey",GenderType.Male),
          new FirstName("Frank",GenderType.Male),
          new FirstName("Gary",GenderType.Male),
          new FirstName("Ryan",GenderType.Male),
          new FirstName("Nicholas",GenderType.Male),
          new FirstName("Eric",GenderType.Male),
          new FirstName("Stephen",GenderType.Male),
          new FirstName("Jacob",GenderType.Male),
          new FirstName("Larry",GenderType.Male),
          new FirstName("Jonathan",GenderType.Male),
          new FirstName("Scott",GenderType.Male),
          new FirstName("Raymond",GenderType.Male),
          new FirstName("Justin",GenderType.Male),
          new FirstName("Brandon",GenderType.Male),
          new FirstName("Gregory",GenderType.Male),
          new FirstName("Samuel",GenderType.Male),
          new FirstName("Benjamin",GenderType.Male),
          new FirstName("Patrick",GenderType.Male),
          new FirstName("Jack",GenderType.Male),
          new FirstName("Henry",GenderType.Male),
          new FirstName("Walter",GenderType.Male),
          new FirstName("Dennis",GenderType.Male),
          new FirstName("Jerry",GenderType.Male),
          new FirstName("Alexander",GenderType.Male),
          new FirstName("Peter",GenderType.Male),
          new FirstName("Tyler",GenderType.Male),
          new FirstName("Douglas",GenderType.Male),
          new FirstName("Harold",GenderType.Male),
          new FirstName("Aaron",GenderType.Male),
          new FirstName("Jose",GenderType.Male),
          new FirstName("Adam",GenderType.Male),
          new FirstName("Arthur",GenderType.Male),
          new FirstName("Zachary",GenderType.Male),
          new FirstName("Carl",GenderType.Male),
          new FirstName("Nathan",GenderType.Male),
          new FirstName("Albert",GenderType.Male),
          new FirstName("Kyle",GenderType.Male),
          new FirstName("Lawrence",GenderType.Male),
          new FirstName("Joe",GenderType.Male),
          new FirstName("Willie",GenderType.Male),
          new FirstName("Gerald",GenderType.Male),
          new FirstName("Roger",GenderType.Male),
          new FirstName("Keith",GenderType.Male),
          new FirstName("Jeremy",GenderType.Male),
          new FirstName("Terry",GenderType.Male),
          new FirstName("Harry",GenderType.Male),
          new FirstName("Ralph",GenderType.Male),
          new FirstName("Sean",GenderType.Male),
          new FirstName("Jesse",GenderType.Male),
          new FirstName("Roy",GenderType.Male),
          new FirstName("Louis",GenderType.Male),
          new FirstName("Billy",GenderType.Male),
          new FirstName("Austin",GenderType.Male),
          new FirstName("Bruce",GenderType.Male),
          new FirstName("Eugene",GenderType.Male),
          new FirstName("Christian",GenderType.Male),
          new FirstName("Bryan",GenderType.Male),
          new FirstName("Wayne",GenderType.Male),
          new FirstName("Russell",GenderType.Male),
          new FirstName("Howard",GenderType.Male),
          new FirstName("Fred",GenderType.Male),
          new FirstName("Ethan",GenderType.Male),
          new FirstName("Jordan",GenderType.Male),
          new FirstName("Philip",GenderType.Male),
          new FirstName("Alan",GenderType.Male),
          new FirstName("Juan",GenderType.Male),
          new FirstName("Randy",GenderType.Male),
          new FirstName("Vincent",GenderType.Male),
          new FirstName("Bobby",GenderType.Male),
          new FirstName("Dylan",GenderType.Male),
          new FirstName("Johnny",GenderType.Male),
          new FirstName("Phillip",GenderType.Male),
          new FirstName("Victor",GenderType.Male),
          new FirstName("Clarence",GenderType.Male),
          new FirstName("Ernest",GenderType.Male),
          new FirstName("Martin",GenderType.Male),
          new FirstName("Craig",GenderType.Male),
          new FirstName("Stanley",GenderType.Male),
          new FirstName("Shawn",GenderType.Male),
          new FirstName("Travis",GenderType.Male),
          new FirstName("Bradley",GenderType.Male),
          new FirstName("Leonard",GenderType.Male),
          new FirstName("Earl",GenderType.Male),
          new FirstName("Gabriel",GenderType.Male),
          new FirstName("Jimmy",GenderType.Male),
          new FirstName("Francis",GenderType.Male),
          new FirstName("Todd",GenderType.Male),
          new FirstName("Noah",GenderType.Male),
          new FirstName("Danny",GenderType.Male),
          new FirstName("Dale",GenderType.Male),
          new FirstName("Cody",GenderType.Male),
          new FirstName("Carlos",GenderType.Male),
          new FirstName("Allen",GenderType.Male),
          new FirstName("Frederick",GenderType.Male),
          new FirstName("Logan",GenderType.Male),
          new FirstName("Curtis",GenderType.Male),
          new FirstName("Alex",GenderType.Male),
          new FirstName("Joel",GenderType.Male),
          new FirstName("Luis",GenderType.Male),
          new FirstName("Norman",GenderType.Male),
          new FirstName("Marvin",GenderType.Male),
          new FirstName("Glenn",GenderType.Male),
          new FirstName("Tony",GenderType.Male),
          new FirstName("Nathaniel",GenderType.Male),
          new FirstName("Rodney",GenderType.Male),
          new FirstName("Melvin",GenderType.Male),
          new FirstName("Alfred",GenderType.Male),
          new FirstName("Steve",GenderType.Male),
          new FirstName("Cameron",GenderType.Male),
          new FirstName("Chad",GenderType.Male),
          new FirstName("Edwin",GenderType.Male),
          new FirstName("Caleb",GenderType.Male),
          new FirstName("Evan",GenderType.Male),
          new FirstName("Antonio",GenderType.Male),
          new FirstName("Lee",GenderType.Male),
          new FirstName("Herbert",GenderType.Male),
          new FirstName("Jeffery",GenderType.Male),
          new FirstName("Isaac",GenderType.Male),
          new FirstName("Derek",GenderType.Male),
          new FirstName("Ricky",GenderType.Male),
          new FirstName("Marcus",GenderType.Male),
          new FirstName("Theodore",GenderType.Male),
          new FirstName("Elijah",GenderType.Male),
          new FirstName("Luke",GenderType.Male),
          new FirstName("Jesus",GenderType.Male),
          new FirstName("Eddie",GenderType.Male),
          new FirstName("Troy",GenderType.Male),
          new FirstName("Mike",GenderType.Male),
          new FirstName("Dustin",GenderType.Male),
          new FirstName("Ray",GenderType.Male),
          new FirstName("Adrian",GenderType.Male),
          new FirstName("Bernard",GenderType.Male),
          new FirstName("Leroy",GenderType.Male),
          new FirstName("Angel",GenderType.Male),
          new FirstName("Randall",GenderType.Male),
          new FirstName("Wesley",GenderType.Male),
          new FirstName("Ian",GenderType.Male),
          new FirstName("Jared",GenderType.Male),
          new FirstName("Mason",GenderType.Male),
          new FirstName("Hunter",GenderType.Male),
          new FirstName("Calvin",GenderType.Male),
          new FirstName("Oscar",GenderType.Male),
          new FirstName("Clifford",GenderType.Male),
          new FirstName("Jay",GenderType.Male),
          new FirstName("Shane",GenderType.Male),
          new FirstName("Ronnie",GenderType.Male),
          new FirstName("Barry",GenderType.Male),
          new FirstName("Lucas",GenderType.Male),
          new FirstName("Corey",GenderType.Male),
          new FirstName("Manuel",GenderType.Male),
          new FirstName("Leo",GenderType.Male),
          new FirstName("Tommy",GenderType.Male),
          new FirstName("Warren",GenderType.Male),
          new FirstName("Jackson",GenderType.Male),
          new FirstName("Isaiah",GenderType.Male),
          new FirstName("Connor",GenderType.Male),
          new FirstName("Don",GenderType.Male),
          new FirstName("Dean",GenderType.Male),
          new FirstName("Jon",GenderType.Male),
          new FirstName("Julian",GenderType.Male),
          new FirstName("Miguel",GenderType.Male),
          new FirstName("Bill",GenderType.Male),
          new FirstName("Lloyd",GenderType.Male),
          new FirstName("Charlie",GenderType.Male),
          new FirstName("Mitchell",GenderType.Male),
          new FirstName("Leon",GenderType.Male),
          new FirstName("Jerome",GenderType.Male),
          new FirstName("Darrell",GenderType.Male),
          new FirstName("Jeremiah",GenderType.Male),
          new FirstName("Alvin",GenderType.Male),
          new FirstName("Brett",GenderType.Male),
          new FirstName("Seth",GenderType.Male),
          new FirstName("Floyd",GenderType.Male),
          new FirstName("Jim",GenderType.Male),
          new FirstName("Blake",GenderType.Male),
          new FirstName("Micheal",GenderType.Male),
          new FirstName("Gordon",GenderType.Male),
          new FirstName("Trevor",GenderType.Male),
          new FirstName("Lewis",GenderType.Male),
          new FirstName("Erik",GenderType.Male),
          new FirstName("Edgar",GenderType.Male),
          new FirstName("Vernon",GenderType.Male),
          new FirstName("Devin",GenderType.Male),
          new FirstName("Gavin",GenderType.Male),
          new FirstName("Jayden",GenderType.Male),
          new FirstName("Chris",GenderType.Male),
          new FirstName("Clyde",GenderType.Male),
          new FirstName("Tom",GenderType.Male),
          new FirstName("Derrick",GenderType.Male),
          new FirstName("Mario",GenderType.Male),
          new FirstName("Brent",GenderType.Male),
          new FirstName("Marc",GenderType.Male),
          new FirstName("Herman",GenderType.Male),
          new FirstName("Chase",GenderType.Male),
          new FirstName("Dominic",GenderType.Male),
          new FirstName("Ricardo",GenderType.Male),
          new FirstName("Franklin",GenderType.Male),
          new FirstName("Maurice",GenderType.Male),
          new FirstName("Max",GenderType.Male),
          new FirstName("Aiden",GenderType.Male),
          new FirstName("Owen",GenderType.Male),
          new FirstName("Lester",GenderType.Male),
          new FirstName("Gilbert",GenderType.Male),
          new FirstName("Elmer",GenderType.Male),
          new FirstName("Gene",GenderType.Male),
          new FirstName("Francisco",GenderType.Male),
          new FirstName("Glen",GenderType.Male),
          new FirstName("Cory",GenderType.Male),
          new FirstName("Garrett",GenderType.Male),
          new FirstName("Clayton",GenderType.Male),
          new FirstName("Sam",GenderType.Male),
          new FirstName("Jorge",GenderType.Male),
          new FirstName("Chester",GenderType.Male),
          new FirstName("Alejandro",GenderType.Male),
          new FirstName("Jeff",GenderType.Male),
          new FirstName("Harvey",GenderType.Male),
          new FirstName("Milton",GenderType.Male),
          new FirstName("Cole",GenderType.Male),
          new FirstName("Ivan",GenderType.Male),
          new FirstName("Andre",GenderType.Male),
          new FirstName("Duane",GenderType.Male),
          new FirstName("Landon", GenderType.Male)
        };

        // Females
        var females = new List<FirstName>
        {
          new FirstName("Mary", GenderType.Female),
          new FirstName("Emma", GenderType.Female),
          new FirstName("Elizabeth", GenderType.Female),
          new FirstName("Minnie", GenderType.Female),
          new FirstName("Margaret", GenderType.Female),
          new FirstName("Ida", GenderType.Female),
          new FirstName("Alice", GenderType.Female),
          new FirstName("Bertha", GenderType.Female),
          new FirstName("Sarah", GenderType.Female),
          new FirstName("Annie", GenderType.Female),
          new FirstName("Clara", GenderType.Female),
          new FirstName("Ella", GenderType.Female),
          new FirstName("Florence", GenderType.Female),
          new FirstName("Cora", GenderType.Female),
          new FirstName("Martha", GenderType.Female),
          new FirstName("Laura", GenderType.Female),
          new FirstName("Nellie", GenderType.Female),
          new FirstName("Grace", GenderType.Female),
          new FirstName("Carrie", GenderType.Female),
          new FirstName("Maude", GenderType.Female),
          new FirstName("Mabel", GenderType.Female),
          new FirstName("Bessie", GenderType.Female),
          new FirstName("Jennie", GenderType.Female),
          new FirstName("Gertrude", GenderType.Female),
          new FirstName("Julia", GenderType.Female),
          new FirstName("Hattie", GenderType.Female),
          new FirstName("Edith", GenderType.Female),
          new FirstName("Mattie", GenderType.Female),
          new FirstName("Rose", GenderType.Female),
          new FirstName("Catherine", GenderType.Female),
          new FirstName("Lillian", GenderType.Female),
          new FirstName("Ada", GenderType.Female),
          new FirstName("Lillie", GenderType.Female),
          new FirstName("Helen", GenderType.Female),
          new FirstName("Jessie", GenderType.Female),
          new FirstName("Louise", GenderType.Female),
          new FirstName("Ethel", GenderType.Female),
          new FirstName("Lula", GenderType.Female),
          new FirstName("Myrtle", GenderType.Female),
          new FirstName("Eva", GenderType.Female),
          new FirstName("Frances", GenderType.Female),
          new FirstName("Lena", GenderType.Female),
          new FirstName("Lucy", GenderType.Female),
          new FirstName("Edna", GenderType.Female),
          new FirstName("Maggie", GenderType.Female),
          new FirstName("Pearl", GenderType.Female),
          new FirstName("Daisy", GenderType.Female),
          new FirstName("Fannie", GenderType.Female),
          new FirstName("Josephine", GenderType.Female),
          new FirstName("Dora", GenderType.Female),
          new FirstName("Rosa", GenderType.Female),
          new FirstName("Katherine", GenderType.Female),
          new FirstName("Agnes", GenderType.Female),
          new FirstName("Marie", GenderType.Female),
          new FirstName("Nora", GenderType.Female),
          new FirstName("May", GenderType.Female),
          new FirstName("Mamie", GenderType.Female),
          new FirstName("Blanche", GenderType.Female),
          new FirstName("Stella", GenderType.Female),
          new FirstName("Ellen", GenderType.Female),
          new FirstName("Nancy", GenderType.Female),
          new FirstName("Effie", GenderType.Female),
          new FirstName("Sallie", GenderType.Female),
          new FirstName("Nettie", GenderType.Female),
          new FirstName("Della", GenderType.Female),
          new FirstName("Lizzie", GenderType.Female),
          new FirstName("Flora", GenderType.Female),
          new FirstName("Susie", GenderType.Female),
          new FirstName("Maud", GenderType.Female),
          new FirstName("Mae", GenderType.Female),
          new FirstName("Etta", GenderType.Female),
          new FirstName("Harriet", GenderType.Female),
          new FirstName("Sadie", GenderType.Female),
          new FirstName("Caroline", GenderType.Female),
          new FirstName("Katie", GenderType.Female),
          new FirstName("Lydia", GenderType.Female),
          new FirstName("Elsie", GenderType.Female),
          new FirstName("Kate", GenderType.Female),
          new FirstName("Susan", GenderType.Female),
          new FirstName("Mollie", GenderType.Female),
          new FirstName("Alma", GenderType.Female),
          new FirstName("Addie", GenderType.Female),
          new FirstName("Georgia", GenderType.Female),
          new FirstName("Eliza", GenderType.Female),
          new FirstName("Lulu", GenderType.Female),
          new FirstName("Nannie", GenderType.Female),
          new FirstName("Lottie", GenderType.Female),
          new FirstName("Amanda", GenderType.Female),
          new FirstName("Belle", GenderType.Female),
          new FirstName("Charlotte", GenderType.Female),
          new FirstName("Rebecca", GenderType.Female),
          new FirstName("Ruth", GenderType.Female),
          new FirstName("Viola", GenderType.Female),
          new FirstName("Olive", GenderType.Female),
          new FirstName("Amelia", GenderType.Female),
          new FirstName("Hannah", GenderType.Female),
          new FirstName("Jane", GenderType.Female),
          new FirstName("Virginia", GenderType.Female),
          new FirstName("Emily", GenderType.Female),
          new FirstName("Matilda", GenderType.Female),
          new FirstName("Irene", GenderType.Female),
          new FirstName("Kathryn", GenderType.Female),
          new FirstName("Esther", GenderType.Female),
          new FirstName("Willie", GenderType.Female),
          new FirstName("Henrietta", GenderType.Female),
          new FirstName("Ollie", GenderType.Female),
          new FirstName("Amy", GenderType.Female),
          new FirstName("Rachel", GenderType.Female),
          new FirstName("Sara", GenderType.Female),
          new FirstName("Estella", GenderType.Female),
          new FirstName("Theresa", GenderType.Female),
          new FirstName("Augusta", GenderType.Female),
          new FirstName("Ora", GenderType.Female),
          new FirstName("Pauline", GenderType.Female),
          new FirstName("Josie", GenderType.Female),
          new FirstName("Lola", GenderType.Female),
          new FirstName("Sophia", GenderType.Female),
          new FirstName("Leona", GenderType.Female),
          new FirstName("Anne", GenderType.Female),
          new FirstName("Mildred", GenderType.Female),
          new FirstName("Ann", GenderType.Female),
          new FirstName("Beulah", GenderType.Female),
          new FirstName("Callie", GenderType.Female),
          new FirstName("Lou", GenderType.Female),
          new FirstName("Delia", GenderType.Female),
          new FirstName("Eleanor", GenderType.Female),
          new FirstName("Barbara", GenderType.Female),
          new FirstName("Iva", GenderType.Female),
          new FirstName("Louisa", GenderType.Female),
          new FirstName("Maria", GenderType.Female),
          new FirstName("Mayme", GenderType.Female),
          new FirstName("Evelyn", GenderType.Female),
          new FirstName("Estelle", GenderType.Female),
          new FirstName("Nina", GenderType.Female),
          new FirstName("Betty", GenderType.Female),
          new FirstName("Marion", GenderType.Female),
          new FirstName("Bettie", GenderType.Female),
          new FirstName("Dorothy", GenderType.Female),
          new FirstName("Luella", GenderType.Female),
          new FirstName("Inez", GenderType.Female),
          new FirstName("Lela", GenderType.Female),
          new FirstName("Rosie", GenderType.Female),
          new FirstName("Allie", GenderType.Female),
          new FirstName("Millie", GenderType.Female),
          new FirstName("Janie", GenderType.Female),
          new FirstName("Cornelia", GenderType.Female),
          new FirstName("Victoria", GenderType.Female),
          new FirstName("Ruby", GenderType.Female),
          new FirstName("Winifred", GenderType.Female),
          new FirstName("Alta", GenderType.Female),
          new FirstName("Celia", GenderType.Female),
          new FirstName("Christine", GenderType.Female),
          new FirstName("Beatrice", GenderType.Female),
          new FirstName("Birdie", GenderType.Female),
          new FirstName("Harriett", GenderType.Female),
          new FirstName("Mable", GenderType.Female),
          new FirstName("Myra", GenderType.Female),
          new FirstName("Sophie", GenderType.Female),
          new FirstName("Tillie", GenderType.Female),
          new FirstName("Isabel", GenderType.Female),
          new FirstName("Sylvia", GenderType.Female),
          new FirstName("Carolyn", GenderType.Female),
          new FirstName("Isabelle", GenderType.Female),
          new FirstName("Leila", GenderType.Female),
          new FirstName("Sally", GenderType.Female),
          new FirstName("Ina", GenderType.Female),
          new FirstName("Essie", GenderType.Female),
          new FirstName("Bertie", GenderType.Female),
          new FirstName("Nell", GenderType.Female),
          new FirstName("Alberta", GenderType.Female),
          new FirstName("Katharine", GenderType.Female),
          new FirstName("Lora", GenderType.Female),
          new FirstName("Rena", GenderType.Female),
          new FirstName("Mina", GenderType.Female),
          new FirstName("Rhoda", GenderType.Female),
          new FirstName("Mathilda", GenderType.Female),
          new FirstName("Abbie", GenderType.Female),
          new FirstName("Eula", GenderType.Female),
          new FirstName("Dollie", GenderType.Female),
          new FirstName("Hettie", GenderType.Female),
          new FirstName("Eunice", GenderType.Female),
          new FirstName("Fanny", GenderType.Female),
          new FirstName("Ola", GenderType.Female),
          new FirstName("Lenora", GenderType.Female),
          new FirstName("Adelaide", GenderType.Female),
          new FirstName("Christina", GenderType.Female),
          new FirstName("Lelia", GenderType.Female),
          new FirstName("Nelle", GenderType.Female),
          new FirstName("Sue", GenderType.Female),
          new FirstName("Johanna", GenderType.Female),
          new FirstName("Lilly", GenderType.Female),
          new FirstName("Lucinda", GenderType.Female),
          new FirstName("Minerva", GenderType.Female),
          new FirstName("Lettie", GenderType.Female),
          new FirstName("Roxie", GenderType.Female),
          new FirstName("Cynthia", GenderType.Female),
          new FirstName("Helena", GenderType.Female),
          new FirstName("Hilda", GenderType.Female),
          new FirstName("Hulda", GenderType.Female),
          new FirstName("Bernice", GenderType.Female),
          new FirstName("Genevieve", GenderType.Female),
          new FirstName("Jean", GenderType.Female),
          new FirstName("Cordelia", GenderType.Female),
          new FirstName("Marian", GenderType.Female),
          new FirstName("Francis", GenderType.Female),
          new FirstName("Jeanette", GenderType.Female),
          new FirstName("Adeline", GenderType.Female),
          new FirstName("Gussie", GenderType.Female),
          new FirstName("Leah", GenderType.Female),
          new FirstName("Lois", GenderType.Female),
          new FirstName("Lura", GenderType.Female),
          new FirstName("Mittie", GenderType.Female),
          new FirstName("Hallie", GenderType.Female),
          new FirstName("Isabella", GenderType.Female),
          new FirstName("Olga", GenderType.Female),
          new FirstName("Phoebe", GenderType.Female),
          new FirstName("Teresa", GenderType.Female),
          new FirstName("Hester", GenderType.Female),
          new FirstName("Lida", GenderType.Female),
          new FirstName("Lina", GenderType.Female),
          new FirstName("Winnie", GenderType.Female),
          new FirstName("Claudia", GenderType.Female),
          new FirstName("Marguerite", GenderType.Female),
          new FirstName("Vera", GenderType.Female),
          new FirstName("Cecelia", GenderType.Female),
          new FirstName("Bess", GenderType.Female),
          new FirstName("Emilie", GenderType.Female),
          new FirstName("John", GenderType.Female),
          new FirstName("Rosetta", GenderType.Female),
          new FirstName("Verna", GenderType.Female),
          new FirstName("Myrtie", GenderType.Female),
          new FirstName("Cecilia", GenderType.Female),
          new FirstName("Elva", GenderType.Female),
          new FirstName("Olivia", GenderType.Female),
          new FirstName("Ophelia", GenderType.Female),
          new FirstName("Georgie", GenderType.Female),
          new FirstName("Elnora", GenderType.Female),
          new FirstName("Violet", GenderType.Female),
          new FirstName("Adele", GenderType.Female),
          new FirstName("Lily", GenderType.Female),
          new FirstName("Linnie", GenderType.Female),
          new FirstName("Loretta", GenderType.Female),
          new FirstName("Madge", GenderType.Female),
          new FirstName("Polly", GenderType.Female),
          new FirstName("Virgie", GenderType.Female),
          new FirstName("Eugenia", GenderType.Female),
          new FirstName("Lucile", GenderType.Female),
          new FirstName("Lucille", GenderType.Female),
          new FirstName("Mabelle", GenderType.Female),
          new FirstName("Rosalie", GenderType.Female)
        };

        names.AddRange(females);

        return names;
      }
      set => _firstNames = value;
    }
  }
}