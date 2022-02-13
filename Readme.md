# NPC Schedule

A highly-extendible scheduling system for Unity. Can technically be used for anything, not just NPCs.

## Installation
Follow the steps [Here](https://github.com/FedoraDevStudios/Installation-Unity) to add this package to your Unity project using this package's URL.

## Usage
### What is a Factory?
A Factory manages the default implementations for your game. If you implement any of the core interfaces and want to use them instead, you can assign them in the Factory so that new objects start with your implementation. Add a `Schedule Factory Behaviour` to your scene. A Factory should have been created as `Assets/Fedora Dev/ScheduleFactory` when you do this, however you can create one with the button.

### Create a Task Pool
The Task Pool holds the tasks that are available to an object. The layout of these tasks are defined by the interface `ITaskPoolItem` and implemented by default in `SimpleTaskPoolItem`. You can create your own implementation of `ITaskPool` to replace the provided `SimpleTaskPool`.

Technically, you can have as many of these as you want, however `SimpleSchedule` will only talk to 1 by default. If you need your schedule to talk to multiple Task Pools, you will have to create an implementation of `IScheduleable`.

You can add every task in your game into the Task Pool, however it may be easier to add your tasks dynamically at runtime. Just make sure all of the available tasks in your game are added before any of the schedules request tasks.

### Schedule
A Schedule is also just a list of tasks, however they will only hold tasks that have been selected from the Task Pool. Tasks in this list are defined by the interface `IScheduleable` and implemented by default in `SimpleScheduleable`. You can also create your own implementations of `ISchedule` to replace the provided `SimpleSchedule`. 

`ScheduleBehaviour` is a wrapper for an `ISchedule` that generates the task list on `Start`. If you want to fill the Task Pool dynamically, be sure to do it in an `Awake` method to ensure the task list is generated before any Schedule requests tasks from it.

### Context
Your project will need its own `IContext` implementation. Context is passed to Filters and Priorities and allow you to grab information specific to your game. This package comes with a default implementation `EmptyContext`. This implementation is useless and has no additional information for your game, so be sure to create your own version. You can also add your implementation to the Factory to make it easier when creating objects.

```C#
public class MyGameContext : IContext
{
	public ScriptableCharacter Character => _character;
	public int AttendantCount => _attendantCount;

	[SerializeField] ScriptableCharacter _character; // Some Scriptable Object class for your character
	[SerializeField] int _attendantCount;

	public IContext Produce(IScheduleFactory scheduleFactory) => new MyGameContext();
}
```

### Filters
By default, this system only comes with `AlwaysTrueFilter` which allows any schedule access to that task, and a `ManyFilter` which allows the use of multiple filters using the given Operation. If you want certain tasks to be filtered per character, then be sure to add what character is requesting the task to your Context and create a new implementation of `ITaskFilter`.

```C#
public class CharacterFilter : ITaskFilter
{
	[SerializeField] ScriptableCharacter _character;

	public ITaskFilter Produce(IScheduleFactory scheduleFactory) => new CharacterFilter();

	public bool IsValid(IContext context)
	{
		MyGameContext gameContext = context as MyGameContext;
		return gameContext.Character == _character;
	}
}
```

### Priorities
By default, this system comes with `SimplePrioritySolver` which allows you to add a numeric priority directly to a task. This is not always useful as certain parameters can change how much a character wants to go to a task.

```C#
public class AttendantQuantityPriority : IPrioritySolver
{
	// Character will want to go the most if there are already exactly 3 attendants. Any more or less will result in a lower priority.
	[SerializeField] _targetAttendants = 3;
	[SerializeField] _perAttendantValue = 10;
	[SerializeField] _highestPriority = 100;

	public IPrioritySolver Produce(IScheduleFactory scheduleFactory) => new AttendantQuantityPriority();

	public int GetPriority(IContext context)
	{
		MyGameContext gameContext = context as MyGameContext;
		int attendantDifference = Mathf.Abs(_targetAttendants - gameContext.AttendantCount);
		return _highestPriority - (attendantDifference * _perAttendantValue);
	}
}
```

### Attendants
##### Note: This is not currently implemented properly.
The more characters that decide to go to a task, the higher the attendant count is. An `AttendantSolver` will allow you to customize how many characters are able to attend that same task at the same time. Because this is not yet fully implemented, documentation will end here.