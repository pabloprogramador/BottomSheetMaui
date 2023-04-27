# Popup and BottomSheet Maui

Two very practical and easy to use components, a main component called Popup and another BottomSheet called Drawer that uses the system of the first one, a good integration that will make it easier to implement any element you want to add on the page.
- **1 file**
- **No Plugins**
- **No Renders ou Handlers**

if you only want to use the Popup Maui just copy the Popup.cs file and the magic happens, but if you want to use BootmSheet Maui just copy Drawer.cs and your BaseDrawer page.


# How to use?

### Create your Popup Maui

```html
<?xml version="1.0" encoding="utf-8" ?>
<base:Popup  xmlns:base="clr-namespace:BottomSheet">
    <Grid>
        <VerticalStackLayout VerticalOptions="Center" HorizontalOptions="Center">
            //YOUR CONTENT
        </VerticalStackLayout>
    </Grid>
</base:Popup>
```
### Open your Popup Maui

```javascript
await Popup.Open(new SamplePopup());
```
<img src="https://raw.githubusercontent.com/pabloprogramador/BottomSheetMaui/main/Images/popup1.gif" height="600">

------------
### Create your BottomSheet Maui

```html
<?xml version="1.0" encoding="utf-8" ?>
<base:DrawerView  xmlns:base="clr-namespace:BottomSheet">
    <Grid>
        <VerticalStackLayout VerticalOptions="Center" HorizontalOptions="Center">
            //YOUR LIST
        </VerticalStackLayout>
    </Grid>
</base:DrawerView>
```
### Open your BottomSheet Maui

```javascript
await Drawer.Open(new MyListDrawerView());
```
|<img src="https://raw.githubusercontent.com/pabloprogramador/BottomSheetMaui/main/Images/popup3.gif" >|<img src="https://raw.githubusercontent.com/pabloprogramador/BottomSheetMaui/main/Images/popup6.gif" >|<img src="https://raw.githubusercontent.com/pabloprogramador/BottomSheetMaui/main/Images/popup5.gif" >|
|--|--|--|




------------
# And many more things to play with:

In file type of DrawerView ou type of Popup you can send a object callback:
```javascript
CallBackReturn.Execute("hello");
```
In ViewModel or Page you resend this callback:
```javascript
string teste = await Drawer.Open(new SampleDrawerView());
//or
string teste = await Popup.Open(new SamplePopup());
```
And also you can make several customizations in your popup file:

```javascript
public async override Task BeforeOpen()
public async override Task AfterOpen()
public async override Task BeforeClose()
public async override Task AfterClose()
```
And also you can block the background:
```javascript
IsCloseOnBackgroundClick = false;
```

And make all kinds of pages that open on top of pages:

<img src="https://raw.githubusercontent.com/pabloprogramador/BottomSheetMaui/main/Images/popup2.gif" height="600">

------------


### And it also has an anti typing monkey block, that is, consecutive clicks that break or duplicate a popup on top of the other

<img src="https://raw.githubusercontent.com/pabloprogramador/BottomSheetMaui/main/Images/monkey.png" height="160">

