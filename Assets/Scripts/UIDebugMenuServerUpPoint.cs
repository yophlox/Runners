using System.Collections.Generic;
using UnityEngine;

public class UIDebugMenuServerUpPoint : UIDebugMenuTask
{
	private enum TextType
	{
		ENERGY,
		RING,
		RED_STAR_RING,
		NUM
	}

	private UIDebugMenuButton m_backButton;

	private UIDebugMenuButton m_decideButton;

	private UIDebugMenuTextField[] m_TextFields = new UIDebugMenuTextField[3];

	private string[] DefaultTextList = new string[3]
	{
		"No. of Additional Challenge",
		"No. of Additional Ring",
		"No. of Additional Red Ring"
	};

	private List<Rect> RectList = new List<Rect>
	{
		new Rect(200f, 200f, 250f, 50f),
		new Rect(200f, 275f, 250f, 50f),
		new Rect(200f, 350f, 250f, 50f)
	};

	private NetDebugUpdPointData m_upPoint;

	protected override void OnStartFromTask()
	{
		m_backButton = base.gameObject.AddComponent<UIDebugMenuButton>();
		m_backButton.Setup(new Rect(200f, 100f, 150f, 50f), "Back", base.gameObject);
		m_decideButton = base.gameObject.AddComponent<UIDebugMenuButton>();
		m_decideButton.Setup(new Rect(200f, 450f, 150f, 50f), "Decide", base.gameObject);
		for (int i = 0; i < 3; i++)
		{
			m_TextFields[i] = base.gameObject.AddComponent<UIDebugMenuTextField>();
			m_TextFields[i].Setup(RectList[i], DefaultTextList[i]);
		}
	}

	protected override void OnTransitionTo()
	{
		if (m_backButton != null)
		{
			m_backButton.SetActive(false);
		}
		if (m_decideButton != null)
		{
			m_decideButton.SetActive(false);
		}
		for (int i = 0; i < 3; i++)
		{
			if (!(m_TextFields[i] == null))
			{
				m_TextFields[i].SetActive(false);
			}
		}
	}

	protected override void OnTransitionFrom()
	{
		if (m_backButton != null)
		{
			m_backButton.SetActive(true);
		}
		if (m_decideButton != null)
		{
			m_decideButton.SetActive(true);
		}
		for (int i = 0; i < 3; i++)
		{
			if (!(m_TextFields[i] == null))
			{
				m_TextFields[i].SetActive(true);
			}
		}
	}

	private void OnClicked(string name)
	{
		if (name == "Back")
		{
			TransitionToParent();
		}
		else
		{
			if (!(name == "Decide"))
			{
				return;
			}
			for (int i = 0; i < 3; i++)
			{
				UIDebugMenuTextField uIDebugMenuTextField = m_TextFields[i];
				int result;
				if (!(uIDebugMenuTextField == null) && !int.TryParse(uIDebugMenuTextField.text, out result))
				{
					return;
				}
			}
			m_upPoint = new NetDebugUpdPointData(int.Parse(m_TextFields[0].text), 0, int.Parse(m_TextFields[1].text), 0, int.Parse(m_TextFields[2].text), 0);
			m_upPoint.Request();
		}
	}
}
