# -Unity-First-Person-View


# **Introduction**

First Person View is an asset that allows you to have a First Person Perspective where first
person objects do not clip through the environment, have a separate field of view from the
environment and can receive shadows from the environment.
In this document i’ll describe how this method works and how to make it work in your project.
Every script is well documented and well structured for you to be able to understand how
everything works and be able to modify and improve it for your specific needs.
This asset was made for free for everyone to support the Unity Community.

![](http://forum.unity3d.com/attachments/firstpersonview_feature-jpg.155452/)

![](http://forum.unity3d.com/attachments/firstpersonview_environmentfov-jpg.155453/)

![](http://forum.unity3d.com/attachments/firstpersonview_environmentfovfpv-jpg.155454/)

# **Features**

## **Game Features**

* ­ First Person View models don’t clip through the environment.
* ­ First Person View models receive shadows from the environment
* ­ Independent Field­of­View between First Person View and the World View
* ­ Ability to choose objects that will or not cast shadows on the First Person View models

## **Script Features**

* ­ Ability to automatically change between World View + First Person View and World View only. (useful when the player interacts with the environment)
* ­ Ability to assign and remove objects to/from the First Person View perspective
* ­ Automatic Layer assignment for First Person Objects. It preserves original layers when changing the objects back to World View

## **Editor Features**

* ­ Automatically create the Camera asset with First Person View ready
* ­ Add/remove First Person Object component to/from selected objects




# **Limitations**

As of now, the only limitations of this system are:

* ­No support for Unity’s Terrain Engine and Terrain Trees. (to be able to use the terrain with this system, you will need to put the terrain in another layer that is not rendered by the First Person View Camera). Normal trees put outside of the terrain system will work good.
* Forward Rendering currently not working



Check the forums for feedback and questions:
http://forum.unity3d.com/threads/free-first-person-view-no-clipping-environment-shadow-support-and-independent-fov.356711/
