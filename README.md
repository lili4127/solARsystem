# solARsystem
ljt2136 COMS 4172

a. Your name and UNI.

Lior Tal ljt2136

b. Date of submission.

3/18/21

c. Computer and OS version.

Macbook Pro 2017. OS Big Sur Version 11.1

d. Mobile device and OS version.

IPhone XS. iOS 14.4

e. Vuforia version.

Vuforia package 9.7.5

License key: AejLLpb/////AAABmeGiylvE2UD9r4kPC9fqyuhq+z5b7jA5nNECdLZnqHxfe3YslsiJnF+AKf5eNvBB0kHYOEHwTXvjUVVqjxFdNOWTG0lslUkc+/iu0B8SZkDyg/Siex66uDcU9d4D/ECWV7UcOfzw96AQn1QWYASAtkl91Q7FKo1zU1PIYOA/+RYABYy5rThEvEP/7CeGODu/fuU9O68SP/u/pfc6cKoWLawvxKrc5amg72vfBM83Fzt5mo9fwTqp+bJeQZheUhzCLSiYjASHs/PGV4FYFCJ2ZgH4iQFQ4A+8gMmo/3J7RMc/AD/nNevpyNiPhZ/MzVJFmMGVkuu4gwM1H51GsvW6xrj8j2kMzHeUwS7y7ZejxQa0

f. Project title.

solARsystem

g. Project directory overview.

The Materials, Prefabs, and Scripts folders in the project window are where the majority of my work can be found. The rest is mainly untouched Vuforia imported assets.

h. Special Instructions, if any, for deploying your app.

Company name/bundle identifier: com.lili.solar

i. Video URL.



j. Missing features.

I implemented all the features asked in the assignment

k. Explanation of bugs you have found in your code and any technology you used.

This is not necessarily a bug however planets will adopt with any orbits they collide with. Therefore, if two orbits overlap, a planet will effectively switch and follow the last orbit it collided with. I was unsure whether or not a planet on an orbit that overlaps with another orbit would need to know to stay on its original orbit, however if this actually existed it could potentially make sense that a planet would switch orbits based on the forces acting on it if such an event were to occur.

If the wand accidentally picks up more than one object (from using the position mode) it may be necessary to restart the application as this will interfere with objects ability to be repositioned. Before restarting one can try to activate delete mode or to simply put back all items picked up to try and get rid of everything on the wand but based on how the objects were picked up it might be difficult or impossible to delete or reposition them as they may not be colliding with the wand.

The orbit image target can also have planets placed on it however it is better to add to orbits already placed in the solar system to avoid errors. This is due to the fact that the select tool creates a duplicate of the item it touches and the wand is meant to only have one object attached to it at a time. If one were to try and create an orbit first and then select it to place it in the solar system, it would confuse the wand and lead to error. This can be understood more from the explanation behind how the select tool works in my assignment write up.

l. Asset sources.

orbit.blend - an orbit I created and imported to unity from blendr. can be found in prefabs folder.

COMS 4172 Database Image Targets
tarmac - sun
vortex - wand
autumn - planets
lego - moons
vortex - orbit

