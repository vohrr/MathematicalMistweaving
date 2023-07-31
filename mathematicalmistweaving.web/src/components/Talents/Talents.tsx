import { Defaults } from "../../common/constants";
import TalentNode, { ChoiceNode, Node } from "./TalentNode";



function TalentTree() {
    let srcUrl;
    if (!srcUrl) {
        srcUrl = Defaults.Talents.Url + Defaults.Talents.TalentString + Defaults.Talents.Options;
    }

    let basicNode: Node = {
        name: "Enveloping Mist",
        row: 1,
        column: 3,
        prereqNodes: undefined,
        selectedRank: 1,
        choiceNode: false,
        maxRank: 1,
        tierActive: true
    };
    let multiRankNode: Node = {
        name: "Rapid Diffusion",
        row: 4,
        column: 7,
        prereqNodes: undefined,
        selectedRank: 0,
        choiceNode: false,
        maxRank: 2,
        tierActive: true
    };
    let choiceOne: Node = {
        name: "Clouded Focus",
        row: 2,
        column: 1,
        prereqNodes: undefined,
        selectedRank: 0,
        choiceNode: true,
        maxRank: 1,
        tierActive: false
    };
    let choiceTwo: Node = {
        name: "Ancient Teachings",
        row: 2,
        column: 1,
        prereqNodes: undefined,
        selectedRank: 0,
        choiceNode: true,
        maxRank: 1,
        tierActive: false
    }
    return (
        <div className="App">
            <h3 >Select Talents:</h3>
            <TalentNode node={basicNode} />
            <TalentNode node={multiRankNode}/>
            <ChoiceNode node={choiceOne} nodeTwo={choiceTwo}/>
            <button type="submit" className="Center"><strong>Calculate</strong></button>
            <div className="iframe">
                <iframe title="talentIframe" src={srcUrl} allowFullScreen={true} height="1000" width="1400" ></iframe>
            </div>

        </div>
    );
}

export default TalentTree;