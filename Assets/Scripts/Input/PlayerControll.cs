// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/PlayerControll.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControll : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControll()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControll"",
    ""maps"": [
        {
            ""name"": ""PlayerControl"",
            ""id"": ""481168c7-0566-4ece-91e7-5b3b000ea203"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""1cbac8f6-4134-48c8-9323-5ef90f09e6bc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""d2b7bf72-928b-4e1b-bbc5-0295ebd7d645"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ScreensControl"",
                    ""type"": ""Button"",
                    ""id"": ""11c78099-bf06-4273-9b2c-3e8d0823200e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WS"",
                    ""id"": ""4e19dac1-efd3-4ddb-b0cf-814e6be0cf4a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""098e5157-fec1-4855-92d7-d8fed58a6e78"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6498bc8c-dfbc-49a7-a282-a640051ccaa6"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9f170876-f7e2-43b7-b152-26b3a619773c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c13e960-ffce-405e-9c9c-4ab7ed91cbb7"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ScreensControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""TouchPad"",
            ""bindingGroup"": ""TouchPad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerControl
        m_PlayerControl = asset.FindActionMap("PlayerControl", throwIfNotFound: true);
        m_PlayerControl_Movement = m_PlayerControl.FindAction("Movement", throwIfNotFound: true);
        m_PlayerControl_Attack = m_PlayerControl.FindAction("Attack", throwIfNotFound: true);
        m_PlayerControl_ScreensControl = m_PlayerControl.FindAction("ScreensControl", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // PlayerControl
    private readonly InputActionMap m_PlayerControl;
    private IPlayerControlActions m_PlayerControlActionsCallbackInterface;
    private readonly InputAction m_PlayerControl_Movement;
    private readonly InputAction m_PlayerControl_Attack;
    private readonly InputAction m_PlayerControl_ScreensControl;
    public struct PlayerControlActions
    {
        private @PlayerControll m_Wrapper;
        public PlayerControlActions(@PlayerControll wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerControl_Movement;
        public InputAction @Attack => m_Wrapper.m_PlayerControl_Attack;
        public InputAction @ScreensControl => m_Wrapper.m_PlayerControl_ScreensControl;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlActions instance)
        {
            if (m_Wrapper.m_PlayerControlActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnMovement;
                @Attack.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnAttack;
                @ScreensControl.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnScreensControl;
                @ScreensControl.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnScreensControl;
                @ScreensControl.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnScreensControl;
            }
            m_Wrapper.m_PlayerControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @ScreensControl.started += instance.OnScreensControl;
                @ScreensControl.performed += instance.OnScreensControl;
                @ScreensControl.canceled += instance.OnScreensControl;
            }
        }
    }
    public PlayerControlActions @PlayerControl => new PlayerControlActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_TouchPadSchemeIndex = -1;
    public InputControlScheme TouchPadScheme
    {
        get
        {
            if (m_TouchPadSchemeIndex == -1) m_TouchPadSchemeIndex = asset.FindControlSchemeIndex("TouchPad");
            return asset.controlSchemes[m_TouchPadSchemeIndex];
        }
    }
    public interface IPlayerControlActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnScreensControl(InputAction.CallbackContext context);
    }
}
