Dynamic Behaviour
Version 1.0

This is a asset to create NPC and player behaviours through simple conditions and fuzzy pattern matching.

Conditions
A Condition is a class that inherits from ScriptableObject. Conditions have a virtual method Verify that takes
an Actor in as a parameter and returns a bool. A condition can be anything a character's health, the time of day
whatever you need in your game, it just has to be accessed through the actor that is calling it.

Acts
An Act is a class that inherits from ScriptableObject. It is the action you want your actor to take. Each act has
list of Conditions which is used to define the state, CheckConditions method, which verifies all the conditions
are met and a virtual PerformAct method. The PerformAct method must be overridden in your new Acts you write, it is
where you put your code for your custom Acts.

Actor
This is the MonoBehaviour used to house all the components it contains the fuzzy pattern matching state machine
as well as some variables that contain states and data used for actor conditions. It uses a coroutine rather than
the update loop so you can control the update rate for each individual Actor.

Player
Player inherits from Actor and contains controller configuration to use with player Conditions. This is where you can
add in custom Player behaviour, or you can make your own class that inherits from Actor.

NPC
NPC inherits from Actor and contains Target to use with NPC Conditions. This is where you can
add in custom NPC behaviour, or you can make your own class that inherits from Actor.

Controller Configuration
This contains 4 directional and 8 additional keys to use for player controls. The whole system currently uses the
old input system but can be easily extended to the new input or other input systems, just make your own class that
inherits from ControllerInput and override the IsActivated method.


Create Condition Script
To make your own custom conditions you need to make a new script that inherits from Condition and the virtual
Verify method must be overridden, that is where you code your condition. To create a new condition script you
make a new C# script and change it from inheriting from MonoBehaviour to Condition. This makes it a Condition
and also a Scriptable Object. You must add a create asset menu header to allow you to create an scriptable 
object instance.
[CreateAssetMenu(fileName = "new Condition", menuName = "ScriptableObjects/Conditions/YourConditionName")]
where YourCondtionName is the name you want to use to select this condition from the create menu.
The Condition must override the the virtual method bool Verify(Actor p_actor) in this method is where 
you put your code for verifying the condition, setting the isTrue bool, and it must return isTrue.
To allow conditions to be inverted you must add in the lines:
if(inverted)
    isTrue=!isTrue;
right before you return isTrue. That will allow you to set the inverted bool in the inspector to invert your 
conditions so you do not need to make opposite conditions.
Conditions have a verify method that returns a bool, so they can be almost anything. There are a lot of
conditions defined already to get you started but you can extend and add in any condition you could need.
Condition is an abstract class inheriting from ScriptableObject, this means that all conditions are scriptable
objects. Conditions have two boolean variables isTrue and inverted, and one method bool Verify(Actor p_actor).
You can make a condition for having low health or possessing a particular item, make one for the time of day or 
anything relevant to your game.

Create Condition ScriptableObject instance
To make a new condition from an existing script just navigate to the folder you want to keep your scriptable 
objects in, then right click right click in the project window and select Create, then ScriptableObject, then 
Condition, then pick the condition you want to create from the list,then you just need to name it. You can 
invert the condition by selecting inverted in the inspector.

	 
Create Act Script
To make your own custom Acts you need to make a new script that inherits from Act and the virtual Verify
method must be overridden, that is where you code your Act, what action you want the actor to take. To
create a new Act script you make a new C# script and change it from inheriting from MonoBehaviour to Act.
This makes it an Act and also a Scriptable Object. You must add a create asset menu header to allow you to
create an scriptable object instance.
[CreateAssetMenu(fileName = "new Act", menuName = "ScriptableObjects/Conditions/YourActName")]
where YourActName is the name you want to use to select this act from the create menu.
The Act must override the the virtual method void PerformAct(Actor p_actor) in this method is where 
you put your code for moving your Actor or whatever you want it to do. An Act is Action your conditions are
the state.

Create Act ScriptableObject instance
To make a new act from an existing script just navigate to the folder you want to keep your scriptable 
objects in, then right click right click in the project window and select Create, then ScriptableObject,
then Act, then pick the act you want to create from the list,then you just need to name it.

Drag Act into Activities List
Acts all have condition lists attached to them. Go in the inspector and expand Conditions if needed you 
select how many conditions you want then drag and drop the conditions in the slots.