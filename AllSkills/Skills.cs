using System;
using Modding;

public class Skills {
    private int? _dashLevel, _dreamNailLevel, _fireballLevel, _quakeLevel, _screamLevel;
    private bool? _dreamNailUpgraded, _hasAcidArmour, _hasCyclone, _hasDash, _hasDashSlash, _hasDoubleJump, _hasDreamNail, _hasShadowDash, _hasSuperDash, _hasUpwardSlash, _hasWalljump;
    public Skills() {
        _dashLevel         = null;
        _dreamNailLevel    = null;
        _dreamNailUpgraded = null;
        _fireballLevel     = null;
        _hasAcidArmour     = null;
        _hasCyclone        = null;
        _hasDash           = null;
        _hasDashSlash      = null;
        _hasDoubleJump     = null;
        _hasDreamNail      = null;
        _hasShadowDash     = null;
        _hasSuperDash      = null;
        _hasUpwardSlash    = null;
        _hasWalljump       = null;
        _quakeLevel        = null;
        _screamLevel       = null;
    }
    private bool HasSkillNewValue(PlayerData pd) {

        return  _dreamNailUpgraded != pd.dreamNailUpgraded ||
                _fireballLevel     != pd.fireballLevel ||
                _hasAcidArmour     != pd.hasAcidArmour ||
                _hasCyclone        != pd.hasCyclone ||
                _hasDashSlash      != pd.hasDashSlash ||
                _hasDoubleJump     != pd.hasDoubleJump ||
                _hasDreamNail      != pd.hasDreamNail ||
                _hasShadowDash     != pd.hasShadowDash ||
                _hasSuperDash      != pd.hasSuperDash ||
                _hasUpwardSlash    != pd.hasUpwardSlash ||
                _hasWalljump       != pd.hasWalljump ||
                _quakeLevel        != pd.quakeLevel ||
                _screamLevel       != pd.screamLevel ||
                _hasDash           != pd.hasDash;
    }
    public void UpdateSkillValues(PlayerData pd) {
        if (HasSkillNewValue(pd)) {
            _dashLevel         = pd.hasShadowDash ? 2 : pd.hasDash ? 1 : 0;
            _dreamNailLevel    = pd.dreamNailUpgraded ? 2 : pd.hasDreamNail ? 1 : 0;
            _dreamNailUpgraded = pd.dreamNailUpgraded;
            _fireballLevel     = pd.fireballLevel;
            _hasAcidArmour     = pd.hasAcidArmour;
            _hasCyclone        = pd.hasCyclone;
            _hasDash           = pd.hasDash;
            _hasDashSlash      = pd.hasUpwardSlash;
            _hasDreamNail      = pd.hasDreamNail;
            _hasDoubleJump     = pd.hasDoubleJump;
            _hasShadowDash     = pd.hasShadowDash;
            _hasSuperDash      = pd.hasSuperDash;
            _hasUpwardSlash    = pd.hasDashSlash;
            _hasWalljump       = pd.hasWalljump;
            _quakeLevel        = pd.quakeLevel;
            _screamLevel       = pd.screamLevel;
        }
    }
    public string toString() {
        string timeString = DateTime.Now.ToString("hh:mm:ss"),
            html = 
                $"<html><body><script>" +
                $"const data = {{" +
                $"skills: {{" +
                    $"acidArmour: {_hasAcidArmour.ToString().ToLower()}," +
                    $"cyclone: {_hasCyclone.ToString().ToLower()}," +
                    $"dashLevel: {_dashLevel}," +
                    $"dreamNailLevel: {_dreamNailLevel}," +
                    $"dashSlash: {_hasDashSlash.ToString().ToLower()}," +
                    $"doubleJump: {_hasDoubleJump.ToString().ToLower()}," +
                    $"fireballLevel: {_fireballLevel.ToString().ToLower()}," +
                    $"focus: true," +
                    $"greatSlash: {_hasUpwardSlash.ToString().ToLower()}," +
                    $"quakeLevel: {_quakeLevel.ToString().ToLower()}," +
                    $"screamLevel: {_screamLevel.ToString().ToLower()}," +
                    $"superDash: {_hasSuperDash.ToString().ToLower()}," +
                    $"wallJump: {_hasWalljump.ToString().ToLower()}," +
                $"}}," +
                $"lastUpdateTime: '{timeString}'" +
                $"}};" +
                $"parent.postMessage(data, \"*\");" +
                $"</script></body></html>";
        return html;
    }
}