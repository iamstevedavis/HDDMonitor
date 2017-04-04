///Created By: Stephen Davis
///
///This little application is a file system watcher for the system tray.
///The application will sit in the system tray once created and begin monitoring the
///default path "C:\". Once it hears an event it will display a graphic appropriate to that event.
///The graphic is a character and is configurable via the "Options" context menu item
///when you right click the icon.
///
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using System.Drawing;
using System.IO;
using System.Threading;

namespace HDDMonitor
{
    static class HDDLight
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationContext applicationContext = new Monitor();
            Application.Run(applicationContext);
        }
    }

    /// <summary>
    /// This class represents a custom application context (as you can see by the inheritance).
    /// Basically, this allows us to start the program without a windows form and run in the system tray.
    /// </summary>
    public partial class Monitor : ApplicationContext
    {
        /// This is the icon that sits in the system tray.
        private NotifyIcon notifyIcon;
        private System.ComponentModel.Container components;
        /// The file watcher
        private FileSystemWatcher sysWatch;
        private frmHDDMonitorMainForm mainForm;
        private frmHDDMonitorAbout aboutForm;
        private ContextMenu notifyIconContextMenu;
        
        /// Some constants to make application configuration a bit easier.
        private const int MAINFORM_WIDTH = 350;
        private const int MAINFORM_HEIGHT = 300;
        private const int STDBUTTON_WIDTH = 75;
        private const int STDBUTTON_HEIGHT = 23;

        /// This is the max buffer size of the system watcher.
        private const int MAX_BUFFER_SIZE = 3;

        /// These represent a basic "enum" that allows me to perform switch statements and such more easily.
        private const int INACTIVITY_ICON = 0;
        private const int CHANGED_ICON = 1;
        private const int CREATED_ICON = 2;
        private const int DELETED_ICON = 3;
        private const int RENAMED_ICON = 4;

        /// The following represents the icons repective to the variable name. icoInactivity for example is the inactivity icon.
        private Icon icoInactivity;
        private Icon icoChanged;
        private Icon icoCreated;
        private Icon icoDeleted;
        private Icon icoRenamed;
        private Icon icoAlotChanged;
        private Icon icoAlotCreated;
        private Icon icoAlotDeleted;
        private Icon icoAlotRenamed;

        ///Holds the last event based on the basic "enum" values above (holds 1 for a changed event)
        private int lastEvent;
        /// Counts the total number of events.
        private int totalEvents;

        /// <summary>
        /// This is the constructor.
        /// </summary>
        public Monitor()
        {
            ///Assign some default icons for our respective events. This also assigns the "!" infront of that respective icon for the heavy use icons.
            ChangeEventIcon(INACTIVITY_ICON, "--");
            ChangeEventIcon(CHANGED_ICON, "$");
            ChangeEventIcon(CREATED_ICON, "C");
            ChangeEventIcon(DELETED_ICON, "D");
            ChangeEventIcon(RENAMED_ICON, "R");
            ///Create the system tray icon context menu (About, Settings and Exit)
            CreateContextMenu();

            this.components = new System.ComponentModel.Container();
            ///Initilize the tray icon with a few starting components.
            this.notifyIcon = new NotifyIcon(components)
            {
                ContextMenuStrip = new ContextMenuStrip(),
                Icon = this.icoInactivity,
                ///This is what the application will be "called" when it is moused over in the system tray.
                Text = "Activity Monitor",
                Visible = true,
                ContextMenu = this.notifyIconContextMenu
            };
            ///Create the file system watcher. Below is the default watch directory.
            this.sysWatch = new FileSystemWatcher();
            /// I made it the working directory because that is really the only "guaranteed" directory to exist at run time.
            this.sysWatch.Path = @"\";
            this.sysWatch.IncludeSubdirectories = true;
            this.sysWatch.EnableRaisingEvents = true;
            this.sysWatch.InternalBufferSize = MAX_BUFFER_SIZE;
            ///Bind my respective event handlers.
            this.sysWatch.Changed += new FileSystemEventHandler(sysWatch_EventHandler);
            this.sysWatch.Created += new FileSystemEventHandler(sysWatch_EventHandler);
            this.sysWatch.Deleted += new FileSystemEventHandler(sysWatch_EventHandler);
            this.sysWatch.Renamed += new RenamedEventHandler(sysWatch_EventHandler);

            this.lastEvent = 0;
            this.totalEvents = 0;
        }

        /// <summary>
        /// This method created the context menu for the system tray icon.
        /// </summary>
        private void CreateContextMenu()
        {
            this.notifyIconContextMenu = new ContextMenu();

            ///Here we create a new context menu item for our icon. This will show the options form.
            MenuItem mnuOptionForm = new MenuItem("Options");
            mnuOptionForm.Click += new EventHandler(mnuOptionForm_Click);
            notifyIconContextMenu.MenuItems.Add(mnuOptionForm);

            ///Here we create a new context menu item for our icon. This is exit.
            MenuItem mnuAbout = new MenuItem("About");
            mnuAbout.Click += new EventHandler(mnuAbout_Click);
            notifyIconContextMenu.MenuItems.Add(mnuAbout);

            ///Here we create a new context menu item for our icon. This is exit.
            MenuItem mnuExit = new MenuItem("Exit");
            mnuExit.Click += new EventHandler(mnuExit_Click);
            notifyIconContextMenu.MenuItems.Add(mnuExit);
        }

        /// <summary>
        /// This function handles the different events that can be sent by the syswatch object.
        /// Technically they could all be seperate event handlers but we don't need that in this case.
        /// I have commented the first event handing situation a lot and not as much for the others because
        /// all the events function in basically the exact same way when they get handled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void sysWatch_EventHandler(object sender, FileSystemEventArgs e)
        {
            ///Handles a renamed event.
            if (e.ChangeType == WatcherChangeTypes.Renamed)
            {
                ///Prevent us from getting anymore events well we process the current one.
                this.sysWatch.EnableRaisingEvents = false;
                ///If the last event was a renamed event and there has been 5 or more rename events...
                if (this.lastEvent == RENAMED_ICON && this.totalEvents >= 5)
                {
                    ///We want to change the icon to represent the high number of this type of event.
                    this.notifyIcon.Icon = this.icoAlotRenamed;
                    this.totalEvents = 0;
                    ///Sleep to give the user time to process the icon.
                    Thread.Sleep(2000);
                }
                ///If the last event was a renamed event but there has not been 5 or more of them...
                else if (this.lastEvent == RENAMED_ICON && this.totalEvents < 5)
                {
                    ///Display the average icon
                    this.notifyIcon.Icon = this.icoRenamed;
                    this.totalEvents++;
                    ///Give the user a quick flash of this event.
                    Thread.Sleep(100);
                }
                ///This case would occur if the last event was some other kind of event.
                else
                {
                    ///Change the last event tracker to this event type.
                    this.lastEvent = RENAMED_ICON;
                    ///Start the counter at 1 because there has been one event (this one).
                    this.totalEvents = 1;
                    this.notifyIcon.Icon = this.icoRenamed;
                    ///Quick flash the user the icon.
                    Thread.Sleep(100);
                }
                ///Re-enable raising events from the system watcher.
                this.sysWatch.EnableRaisingEvents = true;
            }
            ///Handles a deleted event.
            if (e.ChangeType == WatcherChangeTypes.Deleted)
            {
                if (this.lastEvent == DELETED_ICON && this.totalEvents >= 5)
                {
                    this.notifyIcon.Icon = this.icoAlotDeleted;
                    this.totalEvents = 0;
                    ///I set the timer to 1000 for the created event because I feel like this event is more likely to get hit successively.
                    Thread.Sleep(1000);
                }
                else if (this.lastEvent == DELETED_ICON && this.totalEvents < 5)
                {
                    this.notifyIcon.Icon = this.icoDeleted;
                    this.totalEvents++;
                    Thread.Sleep(100);
                }
                else
                {
                    this.lastEvent = DELETED_ICON;
                    this.totalEvents = 1;
                    this.notifyIcon.Icon = this.icoDeleted;
                    Thread.Sleep(100);
                }
            }
            ///Handles a created event.
            if (e.ChangeType == WatcherChangeTypes.Created)
            {
                if (this.lastEvent == CREATED_ICON && this.totalEvents >= 5)
                {
                    this.notifyIcon.Icon = this.icoAlotCreated;
                    this.totalEvents = 0;
                    ///I set the timer to 1000 for the created event because I feel like this event is more likely to get hit successively.
                    Thread.Sleep(1000);
                }
                else if (this.lastEvent == CREATED_ICON && this.totalEvents < 5)
                {
                    this.notifyIcon.Icon = this.icoCreated;
                    this.totalEvents++;
                    Thread.Sleep(100);
                }
                else
                {
                    this.lastEvent = CREATED_ICON;
                    this.totalEvents = 1;
                    this.notifyIcon.Icon = this.icoCreated;
                    Thread.Sleep(100);
                }
            }
            ///Handles a changed event.
            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                this.sysWatch.EnableRaisingEvents = false;
                if (this.lastEvent == CHANGED_ICON && this.totalEvents >= 5)
                {
                    this.notifyIcon.Icon = this.icoAlotChanged;
                    this.totalEvents = 0;
                    Thread.Sleep(2000);
                }
                else if (this.lastEvent == CHANGED_ICON && this.totalEvents < 5)
                {
                    this.notifyIcon.Icon = this.icoChanged;
                    this.totalEvents++;
                    Thread.Sleep(100);
                }
                else
                {
                    this.lastEvent = CHANGED_ICON;
                    this.totalEvents = 1;
                    this.notifyIcon.Icon = this.icoChanged;
                    Thread.Sleep(100);
                }
                this.sysWatch.EnableRaisingEvents = true;
            }
            this.notifyIcon.Icon = this.icoInactivity;
        }

        /// <summary>
        /// This function will either create a new frmHDDMonitorMainForm or activate the 
        /// existing one, bringing the window to front.
        /// </summary>
        private void mnuOptionForm_Click(object sender, EventArgs e)
        {
            if (this.mainForm == null)
            {

                ///Create a new main form and show it.
                this.mainForm = new frmHDDMonitorMainForm();
                ConfigureMainForm();
                PopulateCurrentIconImages();

                Control.ControlCollection formControls = mainForm.Controls;
                Control[] ctrlWatchPath = formControls.Find("txtWatchPath", true);
                TextBox txtWatchPath = (TextBox)ctrlWatchPath[0];
                txtWatchPath.Text = this.sysWatch.Path;

                this.mainForm.Show();
                ///<summary>
                ///Hook onto the closed event so we can null out the
                ///main form... this avoids reshowing
                ///a disposed form.
                ///</summary>
                this.mainForm.Closed += new EventHandler(mainForm_Closed);
            }
            else
            {
                /// The form is currently visible, go ahead and bring it to the front so the user can interact.
                this.mainForm.Activate();
            }
        }

        /// <summary>
        /// This function will either create a new frmHDDMonitorAbout or activate the 
        /// existing one, bringing the window to front.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuAbout_Click(object sender, EventArgs e)
        {
            if (this.aboutForm == null)
            {
                ///Create a new about form and show it.
                this.aboutForm = new frmHDDMonitorAbout();

                this.aboutForm.Show();
                ///<summary>
                ///Hook onto the closed event so we can null out the
                ///main form... this avoids reshowing
                ///a disposed form.
                ///</summary>
                this.aboutForm.Closed += new EventHandler(aboutForm_Closed);
            }
            else
            {
                /// The form is currently visible, go ahead and bring it to the front so the user can interact.
                this.aboutForm.Activate();
            }
        }

        /// <summary>
        /// This function populates the settings form with the current icon sets.
        /// </summary>
        public void PopulateCurrentIconImages()
        {
            Control.ControlCollection formControls = this.mainForm.Controls;///Get the controls on the form.
            PictureBox currentPictureControl = new PictureBox();
            foreach (Control controls in formControls)
            {
                ///Switch to see what control we have and then apply the new control style
                switch (controls.Name)
                {
                    case "picCurrentFileInactivityIcon":
                        currentPictureControl = (PictureBox)controls;
                        currentPictureControl.Image = this.icoInactivity.ToBitmap();
                        break;
                    case "picCurrentFileChangedIcon":
                        currentPictureControl = (PictureBox)controls;
                        currentPictureControl.Image = this.icoChanged.ToBitmap();
                        break;
                    case "picCurrentFileCreateIcon":
                        currentPictureControl = (PictureBox)controls;
                        currentPictureControl.Image = this.icoCreated.ToBitmap();
                        break;
                    case "picCurrentFileDeleteIcon":
                        currentPictureControl = (PictureBox)controls;
                        currentPictureControl.Image = this.icoDeleted.ToBitmap();
                        break;
                    case "picCurrentFileRenameIcon":
                        currentPictureControl = (PictureBox)controls;
                        currentPictureControl.Image = this.icoRenamed.ToBitmap();
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// This method specifies some parameters for the main form including it's size and the apply button.
        /// </summary>
        private void ConfigureMainForm()
        {
            this.mainForm.Width = MAINFORM_WIDTH;
            this.mainForm.Height = MAINFORM_HEIGHT;
            this.mainForm.FormBorderStyle = FormBorderStyle.FixedSingle;

            ///Create the apply button
            Button btnApply = new Button();
            btnApply.Text = "Apply";
            btnApply.Name = "btnApply";
            ///Bind the apply button to an event
            btnApply.Click += new EventHandler(btnApply_Click);
            btnApply.Width = STDBUTTON_WIDTH;
            btnApply.Height = STDBUTTON_HEIGHT;

            int windowWidth = this.mainForm.Width;
            int windowHeight = this.mainForm.Height;

            ///Place the button on the form. The values are arbitrary that help to make the button appear in a nice location.
            btnApply.Location = new Point((windowWidth - (STDBUTTON_WIDTH + 150)), (windowHeight - ((STDBUTTON_HEIGHT + 15) * 2)));
            btnApply.Visible = true;
            this.mainForm.Controls.Add(btnApply);
        }

        /// <summary>
        /// This is the event handler for the apply button on the form. Once it executes it closes the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnApply_Click(object sender, EventArgs e)
        {
            ///Get the controls on the form.
            Control.ControlCollection formControls = this.mainForm.Controls;
            foreach (Control controls in formControls)
            {
                ///Switch to see what control we have and then apply the new control style
                switch (controls.Name)
                {
                    case "txtWatchPath":
                        if (controls.Text != String.Empty)
                        {
                            ///Do a quick check to make sure the directory is valid.
                            DirectoryInfo di = new DirectoryInfo(controls.Text);
                            if (di.Exists)
                            {
                                this.sysWatch.Path = controls.Text;
                                break;
                            }
                            ///If the directory was invalid make sure we tell the user.
                            else
                            {
                                Control[] crtlBadPathErr = formControls.Find("lblBadPathErr", true);
                                Label lblBadPathErr = (Label)crtlBadPathErr[0];
                                lblBadPathErr.Visible = true;

                                Control[] ctrlBadPathErrMsg = formControls.Find("lblBadPathErrMsg", true);
                                Label lblBadPathErrMsg = (Label)ctrlBadPathErrMsg[0];
                                lblBadPathErrMsg.Visible = true;
                                return;
                            }
                        }
                        break;
                    case "txtInactivityLetter":
                        if (controls.Text != String.Empty)
                            ChangeEventIcon(INACTIVITY_ICON, controls.Text);
                        this.notifyIcon.Icon = icoInactivity;
                        break;
                    case "txtFileChangeLetter":
                        if (controls.Text != String.Empty)
                            ChangeEventIcon(CHANGED_ICON, controls.Text);
                        break;
                    case "txtFileCreateLetter":
                        if (controls.Text != String.Empty)
                            ChangeEventIcon(CREATED_ICON, controls.Text);
                        break;
                    case "txtFileDeleteLetter":
                        if (controls.Text != String.Empty)
                            ChangeEventIcon(DELETED_ICON, controls.Text);
                        break;
                    case "txtFileRenameLetter":
                        if (controls.Text != String.Empty)
                            ChangeEventIcon(RENAMED_ICON, controls.Text);
                        break;
                    default:
                        break;
                }
            }
            ///Make the form invisible.
            this.mainForm.Visible = false;
            ///Null out the form to prevent multiple form creation.
            this.mainForm = null;
        }

        /// <summary>
        /// This method handles setting new styles for the different icons that can appear based on what event is fired.
        /// </summary>
        /// <param name="iconName"></param>
        /// <param name="iconLetter">The new icon letter</param>
        private void ChangeEventIcon(int iconName, string iconLetter)
        {
            Bitmap bitmap = null;
            Brush brush = null;
            Graphics graphics = null;
            IntPtr hIcon;

            ///Switch the icon name to find what icon we want to apply new styles for
            switch (iconName)
            {
                case INACTIVITY_ICON:
                    bitmap = new Bitmap(16, 16);
                    brush = new SolidBrush(Color.Blue);
                    graphics = Graphics.FromImage(bitmap);
                    ///"--" will serve as the default icon state when it is in rest.
                    graphics.DrawString(iconLetter, new Font("Helvetica", 13), brush, 0, 0);
                    ///Create a bitmap in memory from a chunk of text.
                    hIcon = bitmap.GetHicon();
                    this.icoInactivity = Icon.FromHandle(hIcon);
                    break;
                case CHANGED_ICON:
                    bitmap = new Bitmap(16, 16);
                    brush = new SolidBrush(Color.Green);
                    graphics = Graphics.FromImage(bitmap);
                    ///Change the icon to an "C" for change
                    graphics.DrawString(iconLetter, new Font("Helvetica", 13), brush, 0, 0);
                    hIcon = bitmap.GetHicon();
                    this.icoChanged = Icon.FromHandle(hIcon);

                    bitmap.Dispose();
                    brush.Dispose();
                    graphics.Dispose();

                    bitmap = new Bitmap(16, 16);
                    brush = new SolidBrush(Color.Red);
                    graphics = Graphics.FromImage(bitmap);
                    ///Change the icon to an "!C" for mane changes
                    graphics.DrawString("!" + iconLetter, new Font("Helvetica", 11), brush, 0, 0);
                    hIcon = bitmap.GetHicon();
                    this.icoAlotChanged = Icon.FromHandle(hIcon);
                    break;
                case CREATED_ICON:
                    bitmap = new Bitmap(16, 16);
                    brush = new SolidBrush(Color.Green);
                    graphics = Graphics.FromImage(bitmap);
                    ///Change the icon to an "N" for created (new)
                    graphics.DrawString(iconLetter, new Font("Helvetica", 13), brush, 0, 0);
                    hIcon = bitmap.GetHicon();
                    this.icoCreated = Icon.FromHandle(hIcon);

                    bitmap.Dispose();
                    brush.Dispose();
                    graphics.Dispose();

                    bitmap = new Bitmap(16, 16);
                    brush = new SolidBrush(Color.Red);
                    graphics = Graphics.FromImage(bitmap);
                    ///Change the icon to an "!N" for a lot of created items (new)
                    graphics.DrawString("!" + iconLetter, new Font("Helvetica", 11), brush, 0, 0);
                    hIcon = bitmap.GetHicon();
                    this.icoAlotCreated = Icon.FromHandle(hIcon);
                    break;
                case DELETED_ICON:
                    bitmap = new Bitmap(16, 16);
                    brush = new SolidBrush(Color.Red);
                    graphics = Graphics.FromImage(bitmap);
                    ///Change the icon to an "D" for delete
                    graphics.DrawString(iconLetter, new Font("Helvetica", 13), brush, 0, 0);
                    hIcon = bitmap.GetHicon();
                    this.icoDeleted = Icon.FromHandle(hIcon);

                    bitmap.Dispose();
                    brush.Dispose();
                    graphics.Dispose();

                    bitmap = new Bitmap(16, 16);
                    brush = new SolidBrush(Color.Red);
                    graphics = Graphics.FromImage(bitmap);
                    ///Change the icon to an "!D" for heavy deletes
                    graphics.DrawString("!" + iconLetter, new Font("Helvetica", 11), brush, 0, 0);
                    hIcon = bitmap.GetHicon();
                    this.icoAlotDeleted = Icon.FromHandle(hIcon);
                    break;
                case RENAMED_ICON:
                    bitmap = new Bitmap(16, 16);
                    brush = new SolidBrush(Color.Green);
                    graphics = Graphics.FromImage(bitmap);
                    ///Change the icon to an "R" for rename
                    graphics.DrawString(iconLetter, new Font("Helvetica", 13), brush, 0, 0);
                    hIcon = bitmap.GetHicon();
                    this.icoRenamed = Icon.FromHandle(hIcon);

                    bitmap.Dispose();
                    brush.Dispose();
                    graphics.Dispose();

                    bitmap = new Bitmap(16, 16);
                    brush = new SolidBrush(Color.Red);
                    graphics = Graphics.FromImage(bitmap);
                    ///Change the icon to an "!R" for heavy renames
                    graphics.DrawString("!" + iconLetter, new Font("Helvetica", 11), brush, 0, 0);
                    hIcon = bitmap.GetHicon();
                    this.icoAlotRenamed = Icon.FromHandle(hIcon);
                    break;
                default:
                    break;
            }
            ///Housekeeping!
            bitmap.Dispose();
            brush.Dispose();
            graphics.Dispose();
        }

        /// <summary>
        /// This is the event that fires when the main form is closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainForm_Closed(object sender, EventArgs e)
        {
            ///Null out the main form so we know to create a new one.
            this.mainForm = null;
        }

        /// <summary>
        /// This is the event that fires when the about form is closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutForm_Closed(object sender, EventArgs e)
        {
            ///Null out the about form so we know to create a new one.
            this.aboutForm = null;
        }

        /// <summary>
        /// Called when the context menu item Exit is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void mnuExit_Click(object sender, EventArgs e)
        {
            ExitThread();
        }

        /// <summary>
        /// Called on dispose.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            ExitThread();
            if (disposing && components != null) { components.Dispose(); }
        }

        /// <summary>
        /// Called when the thread is closing.
        /// </summary>
        protected override void ExitThreadCore()
        {
            this.notifyIcon.Visible = false;
            base.ExitThreadCore();
        }
    }
}
