# Fake Rest
Fake Rest Repository with already available data to play around.

## Available Datasets
* Users
* Jeopardy Questions
* Nasa Facilities (Nasa Open Data)
* Nasa Patents (Nasa Open Data)

## Live Version
http://fakerest.sparekh.com/


## Adding a new Json Dataset
* Add the new Json file with name conventions : **EntityName**JsonData.json
* Make sure the Json sturcture of the entity has an Id field.
* Create a new class in Models folder with the same **EntiyName** as in the name of json dataset file.
* Derive the new class from BaseClass and implemnt GetSearchableText method. This methods returns a string made of Searchable fields and used by search function.
* Add a new Controller for the Entity and derive it from BaseController<EntityName>
* Provide proper route the access the new controller and that's all. The BaseController has all the Logic to handle requests.

## User Class Example

```
public class User : BaseClass
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Avatar { get; set; }
        public override string GetSearchableText()
        {
            return Id + FirstName + LastName + Email + Gender;
        }
    }
```

## User Controller Example
```
[RoutePrefix("api/user")]
public class UserController : BaseController<User>
{
}
```
