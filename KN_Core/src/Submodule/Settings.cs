namespace KN_Core.Submodule {
  public class Settings : BaseMod {
    private bool rPoints_;
    public bool RPoints {
      get => rPoints_;
      set {
        rPoints_ = value;
        Core.ModConfig.Set("r_points", value);
        GameConsole.Bool["r_points"] = value;
        GameConsole.UpdatePoints();
      }
    }

    private bool hideNames_;
    public bool HideNames {
      get => hideNames_;
      set {
        hideNames_ = value;
        Core.ModConfig.Set("hide_names", value);
      }
    }

    public Settings(Core core) : base(core, "SETTINGS", int.MaxValue - 1) { }

    public void Awake() {
      RPoints = Core.ModConfig.Get<bool>("r_points");
      HideNames = Core.ModConfig.Get<bool>("hide_names");
    }

    public override void OnStop() {
      Core.ModConfig.Set("r_points", RPoints);
      Core.ModConfig.Set("hide_names", HideNames);
    }

    public override void OnGUI(int id, Gui gui, ref float x, ref float y) {
      x += Gui.OffsetSmall;

      if (gui.Button(ref x, ref y, "HIDE POINTS", RPoints ? Skin.Button : Skin.ButtonActive)) {
        RPoints = !RPoints;
      }

      if (gui.Button(ref x, ref y, "HIDE NAMES", HideNames ? Skin.Button : Skin.ButtonActive)) {
        HideNames = !HideNames;
      }
    }
  }
}